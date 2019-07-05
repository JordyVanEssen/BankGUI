using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WebSocketSharp;
using System.Windows.Forms;
using Bank_Project_3_4.Models;
using BankDataLayer;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;

namespace Bank_Project_3_4
{
    class CentralBankConnection
    {
        // the connections to the websocket server
        static WebSocket _master = new WebSocket("ws://145.24.222.24:8080");
        static WebSocket _slave = new WebSocket("ws://145.24.222.24:8080");
        static MessageQueue _mq;
        static HttpRequest _http = new HttpRequest();



        public CentralBankConnection()
        {
            // start the threads
            Thread _threadSlave = new Thread(new ThreadStart(() => connection(_slave, "slave")));
            Thread _threadMaster = new Thread(new ThreadStart(() => connection(_master, "master")));
            Thread handleOutgoingMessage = new Thread(new ThreadStart(getMessage));

            _threadSlave.Start();
            _threadMaster.Start();

            Thread.Sleep(500);

            handleOutgoingMessage.Start();
        }

        public static void sendCommand(String pCommand)
        {
            _master.Send(pCommand);
        }

        public static void connection(WebSocket pSocket, String pMode)
        {
            pSocket.OnOpen += (sender, e) =>
                Console.WriteLine("Connection open");

            pSocket.OnMessage += (sender, e) => {
                // if there is a message received -> write it to file -> send to the handlecommand funciton
                writeToFile($"Response: {e.Data}");
                if (e.Data.ToLower().Contains("true") || e.Data.ToLower().Contains("false"))
                {
                    if (_mq != null)
                    {
                        if (_mq.Function.Equals("pinCheck") || _mq.Function.Equals("withdraw"))
                        {
                            if (e.Data.ToLower().Contains("true"))
                            {
                                updateMessage(true);
                            }
                            else
                            {
                                updateMessage(false);
                            }
                        }
                    }
                }
                else
                {
                    handleCommand(pSocket, e.Data);
                }
            };

            pSocket.OnError += (sender, e) => {
                writeToFile(e.Message);
            };

            pSocket.OnClose += WsOnOnClose;

            if (pSocket.ReadyState != WebSocketState.Open)
            {
                pSocket.Connect();
            }

            if (pSocket.ReadyState == WebSocketState.Open)
            {
                pSocket.Send($"[\"register\", \"{pMode}\", \"supils\"]");
            }
        }

        private static void WsOnOnClose(object sender, CloseEventArgs closeEventArgs)
        {
            // if the connection closes
            if (!closeEventArgs.WasClean)
            {
                if (!_master.IsAlive)
                {
                    Console.WriteLine("Connection master closed");
                    Thread.Sleep(2000);
                    _master.Connect();
                }

                if (!_slave.IsAlive)
                {
                    Console.WriteLine("Connection slave closed");
                    Thread.Sleep(2000);
                    _slave.Connect();
                }
            }
        }

        static async void handleCommand(WebSocket pSocket, String pCommand)
        {
            // handles the incoming commands           
            writeToFile($"Message received: {pCommand}");

            // because the central bank is retarted i have to replace all characters....
            pCommand = pCommand.Replace("[", "");
            pCommand = pCommand.Replace("]", "");

            pCommand = pCommand.Replace("\'", "\"");
            pCommand = pCommand.Replace("\"{", "{");
            pCommand = pCommand.Replace("}\"", "}");

            pCommand = pCommand.Replace(",\"Amount\":null", "");
            pCommand = pCommand.Replace("\\", "");

            // converts the incoming json to usefull info
            JsonPayload recieveCommand = JsonConvert.DeserializeObject<JsonPayload>(pCommand);

            // checks if the credentials are valid
            int valid = await _http.httpGetRequest($"Authentication/{recieveCommand.PIN}/{recieveCommand.IBAN}");

            // the client wants to withdraw
            if (recieveCommand.Func.Equals("withdraw") && valid == 1)
            {
                int amount = Convert.ToInt32(recieveCommand.Amount);
                await _http.httpGetRequest($"Withdraw/{recieveCommand.IBAN}/ATM/{amount}/{recieveCommand.PIN}");
                writeToFile("Sent: [\"true\"]");
                pSocket.Send("[\"true\"]");
            }
            else if (recieveCommand.Func.Equals("pinCheck") && valid == 1)
            {
                // just login
                writeToFile("Sent: [\"true\"]");
                pSocket.Send("[\"true\"]");
            }
            else
            {
                writeToFile("Sent: [\"false\"]");
                pSocket.Send("[\"false\"]");
            }
        }

        public async void getMessage()
        {
            MessageQueue previousMq = new MessageQueue();

            while (true)
            {
                while (true)
                {
                    // gets a waitting messagequeue
                    _mq = await _http.getMessageQueue($"MessageQueues");

                    if (_mq != null && _mq.MessageId != previousMq.MessageId)
                        break;

                    Thread.Sleep(2000);
                }

                previousMq = _mq;
                JsonPayload jsonMessage = JsonConvert.DeserializeObject<JsonPayload>(_mq.DataObject);

                if (_mq.Function.Equals("pinCheck"))
                {
                    jsonMessage.Amount = 0;
                }

                String sMsg = JsonConvert.SerializeObject(jsonMessage);
                
                // replace all the characters because the central bank is too **** to handle 
                // normal Json -.-
                sMsg = sMsg.Replace("\"", "\'");
                sMsg = sMsg.Replace("{", "\"{");
                sMsg = sMsg.Replace("}", "}\"");

                if (_mq != null)
                {
                    String msgToSend = $"[\"{jsonMessage.IDRecBank}\", {sMsg}]";

                    msgToSend = Regex.Replace(msgToSend, @"\t|\n|\r", "");

                    try
                    {
                        writeToFile($"Message sent: {msgToSend}");
                        // sends the message to the central bank
                        _master.Send(msgToSend);
                    }
                    catch (Exception ex)
                    {
                        // onerror
                        Helper.showMessage(ex.Message);
                    }
                }
            }
        }

        public async static void updateMessage(Boolean pValid)
        {
            // updates the messagequeue in the database so the api can valid 
            if (pValid)
            {
                _mq.ValidPassword = true;
            }
            else
            {
                _mq.ValidPassword = false;
            }
            _mq.StatusCode = 2;

            await _http.UpdateMessageQueueAsync(_mq, $"MessageQueues");
        }

        public void close()
        {
            // closes the connection
            _master.Close();
            _slave.Close();
        }

        public static void writeToFile(String pText)
        {
            // all the incoming and ougoing messages are saved in a log file
            ReaderWriterLock locker = new ReaderWriterLock();
            try
            {
                lock (@"..\..\Log.txt")
                {
                    File.AppendAllText(@"..\..\Log.txt", $"{DateTime.Now} - {pText}\r\n");
                }
               
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
