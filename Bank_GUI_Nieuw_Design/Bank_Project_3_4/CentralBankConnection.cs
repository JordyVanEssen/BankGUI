using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WebSocketSharp;

namespace Bank_Project_3_4
{
    class CentralBankConnection
    {
        static WebSocket _master = new WebSocket($"ws://127.0.0.1:6666");
        static WebSocket _slave = new WebSocket($"ws://127.0.0.1:6666");
        static String _lastCommand = string.Empty;

        public CentralBankConnection()
        {
            Thread _threadSlave = new Thread(new ThreadStart(() => connection(_slave, "slave")));
            Thread _threadMaster = new Thread(new ThreadStart(() => connection(_master, "master")));

            _threadSlave.Start();
            _threadMaster.Start();
        }

        public static void sendCommand(String pCommand)
        {
            _slave.Send(pCommand);
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
            String[] pieces = pCommand.Split(new[] { ',' }, 6);

            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i] = pieces[i].Replace("[", "");
                pieces[i] = pieces[i].Replace('"', ' ');
                pieces[i] = pieces[i].Replace("]", "");
                pieces[i] = pieces[i].Trim();

                if (!string.IsNullOrEmpty(pieces[i]))
                    Console.WriteLine(pieces[i]);
            }

            String command = pieces[1];

            http = new HttpRequest("Authentication");
            int valid = Convert.ToInt32(await HttpRequest.AuthenticationAsync(http.createUrl(), $"{pieces[4]}/{pieces[3].ToUpper()}"));

            if (command.Equals("withdraw") && valid == 1)
            {
                int amount = Int32.Parse(pieces[3]);
                http = new HttpRequest("Withdraw", $"{pieces[1].ToUpper()}/ATM/{amount}");
                await HttpRequest.withdrawAsync(http.createUrl());
                _slave.Send("[\"true\"]");
            }
            else if (command.Equals("pinCheck") && valid == 1)
            {
                _slave.Send("[\"true\"]");
            }
            else
            {
                _slave.Send("[\"false\"]");
            }
        }
    }
}
