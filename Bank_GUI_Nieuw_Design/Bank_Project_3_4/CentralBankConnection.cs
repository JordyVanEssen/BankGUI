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
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace Bank_Project_3_4
{
    class CentralBankConnection
    {
        static WebSocket _master = new WebSocket("ws://145.24.222.24:8080");
        static WebSocket _slave = new WebSocket("ws://145.24.222.24:8080");
        static String _lastCommand = string.Empty;

        public CentralBankConnection()
        {
            Thread _threadSlave = new Thread(new ThreadStart(() => connection(_slave, "slave")));
            Thread _threadMaster = new Thread(new ThreadStart(() => connection(_master, "master")));
            Thread handleOutgoingMessage = new Thread(new ThreadStart(getMessage));

            _threadSlave.Start();
            _threadMaster.Start();
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
                    if (_lastCommand.Equals("checkPin") && e.Data.ToLower().Contains("true"))
                    {
                        DeBank._validPass = true;
                    }
                    else if (_lastCommand.Equals("withdraw") && e.Data.ToLower().Contains("true"))
                    {
                        using (FormLogOut logOutForm = new FormLogOut())
                        {
                            if (logOutForm.ShowDialog() == DialogResult.OK)
                            {
                                DeBank bank = new DeBank();
                                bank.logOut();
                            }
                        }
                    }
                }
                else
                {
                    handleCommand(e.Data);
                }
            };

            pSocket.OnClose += (sender, e) => { };
            pSocket.Connect();

            if (pSocket.ReadyState != WebSocketState.Open)
            {
                pSocket.Connect();
            }

            if (pSocket.ReadyState == WebSocketState.Open)
            {
                pSocket.Send($"[\"register\", \"{pMode}\", \"pils\"]");
            }
        }

        static async void handleCommand(String pCommand)
        {
            HttpRequest http;

            JsonPayload recieveCommand = JsonConvert.DeserializeObject<JsonPayload>(pCommand);

            http = new HttpRequest("Authentication");
            int valid = Convert.ToInt32(await HttpRequest.AuthenticationAsync(http.createUrl(), $"{recieveCommand.PIN}/{recieveCommand.IBAN.ToUpper()}"));

            if (recieveCommand.Func.Equals("withdraw") && valid == 1)
            {
                int amount = Convert.ToInt32(recieveCommand.Amount);
                http = new HttpRequest("Withdraw", $"{recieveCommand.IBAN.ToUpper()}/ATM/{amount}");
                await HttpRequest.withdrawAsync(http.createUrl());
                _master.Send("[\"true\"]");
            }
            else if (recieveCommand.Func.Equals("checkPin") && valid == 1)
            {
                _master.Send("[\"true\"]");
            }
            else
            {
                _master.Send("[\"false\"]");
            }
        }

        public async void getMessage()
        {
            HttpRequest http = new HttpRequest("MessageQueues");
            MessageQueue mq;

            while (true)
            {
                mq = await HttpRequest.getMessageQueue(http.createUrl());

                if (mq != null)
                    break;

                Thread.Sleep(2000);
            }

            //JsonPayload msg = JsonConvert.DeserializeObject<JsonPayload>(mq.DataObject);
            //String sMsg = Convert.ToString(mq.DataObject);

            JObject jo = JObject.Parse(mq.DataObject);
            jo.Property("Amount").Remove();
            String sMsg = jo.ToString();

            if (mq != null)
            {
                String msgToSend = $"['{jo.Property("revBank").Value}', '{Convert.ToString(sMsg)}']";
                msgToSend = Regex.Replace(msgToSend, @"\t|\n|\r", "");
                try
                {
                    _master.Send(msgToSend);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            getMessage();
        }
    }
}
