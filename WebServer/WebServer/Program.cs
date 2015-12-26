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
            
            /*string temp = "";
            using (FileStream fs = new FileStream("D:\\request2.txt", FileMode.Open))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(string));
                temp += (string)dcs.ReadObject(fs);
            }

            RequestParser parser = new RequestParser(temp);
            parser.Parse();
            MyHashTable<string, string> form = parser.Form;

            Console.WriteLine("FORM");

            if (form != null)
            {
                foreach (var item in form)
                {
                    Console.WriteLine(item.Key + " - " + item.Value);
                }
            }            
            
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            MyHashTable<string, string> requeste = parser.Parse();
            foreach (var item in requeste)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
            Console.ReadKey();  */       
        }
    }
}
