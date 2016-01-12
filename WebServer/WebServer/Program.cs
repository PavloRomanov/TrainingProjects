using System;
using System.IO;
using System.Runtime.Serialization;
using CollectionLibrary;
using Routing;


namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Run(14000);          
        }
    }
}
