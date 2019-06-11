using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WebSocketSharp;

namespace Bank_Project_3_4
{
    class WebsocketConnection
    {
        static WebSocket _master = new WebSocket($"ws://127.0.0.1:6666");
        static WebSocket _slave = new WebSocket($"ws://127.0.0.1:6666");

        public WebsocketConnection()
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

            pSocket.OnMessage += (sender, e) =>
                handleCommand(e.Data);

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

            String command = pieces[0];

            if (command.Equals("withdraw"))
            {
                HttpRequest http = new HttpRequest("Authentication");
                int valid = Convert.ToInt32(await HttpRequest.AuthenticationAsync(http.createUrl(), $"{pieces[2]}/{pieces[1].ToUpper()}"));

                if (valid == 1)
                {
                    double amount = double.Parse(pieces[3]);
                    http = new HttpRequest("Withdraw", $"{pieces[1].ToUpper()}/ATM/{amount / 10}");
                    await HttpRequest.withdrawAsync(http.createUrl());
                    _slave.Send("[\"True\"]");
                }
                else
                {
                    _slave.Send("[\"False\"]");
                }
            }
        }
    }
}
