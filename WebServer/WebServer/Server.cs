﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WebServer
{
    static class Server
    {
        public static void Run(int port)
        {
            var listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            while (true)
            {
                var client = listener.AcceptTcpClient();
                new Thread(ClientThread).Start(client);
                //Thread.Sleep(10000);

            }

            //listener.Stop();
        }

        private static void ClientThread(object stateInfo)
        {
            Object block = new Object();
            lock (block)
            {
                var client = (TcpClient)stateInfo;
                try
                {
                    Client.Handle(client);

                }
                finally
                {
                    client.Close();
                }
            }
           
        }
    }
}
