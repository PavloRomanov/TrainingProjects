using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routing.Pages;
using System.Runtime.Serialization;
using CollectionLibrary;

namespace UnitTestWebServer
{
    [TestClass]
    public class PageTest
    {
        [TestMethod]
        public void CreateClientTestMethod1()
        {           
            CreateClient cc1 = new CreateClient();
           // string respons = cc.Get(null).Content;
            
             using (FileStream fs = new FileStream("D:\\CreateClient.html", FileMode.Create))
             {
                 DataContractSerializer dcs = new DataContractSerializer(typeof(string));
               // dcs.WriteObject(fs, respons);
             }
             
         }
        
    }
}
