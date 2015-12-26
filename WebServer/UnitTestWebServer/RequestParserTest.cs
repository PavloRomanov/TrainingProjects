using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using WebServer;

namespace UnitTestWebServer
{
    [TestClass]
    public class RequestParserTest
    {
        /* [TestMethod]
         public void TestMethod1()
         {
             string temp = "";
             using (FileStream fs = new FileStream("D:\\request.txt", FileMode.Open))
             {
                 DataContractSerializer dcs = new DataContractSerializer(typeof(string));
                 temp += (string)dcs.ReadObject(fs);
             }

             RequestParser parser = new RequestParser(temp);

             parser.ShouAllRequestLine();
             string method = parser.GetRequestMethod();
             Assert.IsTrue(method == "GET");
         }

         [TestMethod]
         public void TestMethod2()
         {
             string temp = "";
             using (FileStream fs = new FileStream("D:\\request.txt", FileMode.Open))
             {
                 DataContractSerializer dcs = new DataContractSerializer(typeof(string));
                 temp += (string)dcs.ReadObject(fs);
             }

             RequestParser parser = new RequestParser(temp);

             string requestURI = parser.GetPath();
             Assert.IsTrue(requestURI =="/action_page.php" );
         }

         [TestMethod]
         public void TestMethod3()
         {
             string temp = "";
             using (FileStream fs = new FileStream("D:\\request.txt", FileMode.Open))
             {
                 DataContractSerializer dcs = new DataContractSerializer(typeof(string));
                 temp += (string)dcs.ReadObject(fs);
             }

             RequestParser parser = new RequestParser(temp);

             string method = parser.GetRequestMethod();
             parser.GetPath();
             parser.GetFormParameters();
             //parser.GetRestParameters();
             parser.ShowMessage();
             Assert.IsTrue(method == "GET");
         }*/
    }
}
