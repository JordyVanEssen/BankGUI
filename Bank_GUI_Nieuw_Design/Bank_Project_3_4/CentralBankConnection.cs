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

namespace Bank_Project_3_4
{
    class CentralBankConnection
    {
        static WebSocket _master = new WebSocket("ws://145.24.222.24:8080");
        static WebSocket _slave = new WebSocket("ws://145.24.222.24:8080");
        //static WebSocket _master = new WebSocket("ws://localhost:6666");
        //static WebSocket _slave = new WebSocket("ws://localhost:6666");
        static MessageQueue _mq;
        static HttpRequest _http = new HttpRequest("MessageQueues");



        public CentralBankConnection()
        {
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
                Console.WriteLine(e.Message);
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
            pCommand = pCommand.Replace("[", "");
            pCommand = pCommand.Replace("]", "");

            var j = JsonConvert.SerializeObject(pCommand);

            pCommand = pCommand.Replace("\'", "\"");
            pCommand = pCommand.Replace("\"{", "{");
            pCommand = pCommand.Replace("}\"", "}");

            pCommand = pCommand.Replace("Amount", "");
            pCommand = pCommand.Replace("null", "");
            pCommand = pCommand.Replace(":", "");

            JsonPayload recieveCommand = JsonConvert.DeserializeObject<JsonPayload>(pCommand);


            _http = new HttpRequest("Authentication");
            int valid = Convert.ToInt32(await HttpRequest.AuthenticationAsync(_http.createUrl(), $"{recieveCommand.PIN}/{recieveCommand.IBAN}"));

            if (recieveCommand.Func.Equals("withdraw") && valid == 1)
            {
                int amount = Convert.ToInt32(recieveCommand.Amount);
                _http = new HttpRequest("Withdraw", $"{recieveCommand.IBAN}/ATM/{amount}");
                await HttpRequest.withdrawAsync(_http.createUrl());
                pSocket.Send("[\"true\"]");
            }
            else if (recieveCommand.Func.Equals("pinCheck") && valid == 1)
            {
                pSocket.Send("[\"true\"]");
            }
            else
            {
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
                    _http = new HttpRequest("MessageQueues");
                    _mq = await HttpRequest.getMessageQueue(_http.createUrl());

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
                //fix java
                sMsg = sMsg.Replace("\"", "\'");
                sMsg = sMsg.Replace("{", "\"{");
                sMsg = sMsg.Replace("}", "}\"");

                if (_mq != null)
                {
                    String msgToSend = $"[\"{jsonMessage.IDRecBank}\", {sMsg}]";

                    msgToSend = Regex.Replace(msgToSend, @"\t|\n|\r", "");

                    //String jsonString = $"{jo.Property("IDSenBank").Value}";
                    try
                     {
                        _master.Send(msgToSend);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }

        public async static void updateMessage(Boolean pValid)
        {
            if (pValid)
            {
                _mq.ValidPassword = true;
            }
            else
            {
                _mq.ValidPassword = false;
            }
            _mq.StatusCode = 2;

            HttpRequest http = new HttpRequest("MessageQueues");
            await HttpRequest.UpdateMessageQueueAsync(_mq, http.createUrl());
        }

        public void close()
        {
            _master.Close();
            _slave.Close();
        }
    }
}
