using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using Routing;
using Routing.Pages;
using CollectionLibrary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace WebServer
{
    static class Client
    {      
        public static void Handle(TcpClient client)
        {
            var stream = client.GetStream();
         
            try
            {
                var requestString = GetRequest(stream);

                RequestParser parser = new RequestParser(requestString);
                MyHashTable<string, string> request = parser.Parse();

                MyHashTable<string, string> cookies = parser.Cookies;
              
                string startLine = parser.startLine;

                if (startLine == string.Empty)
                {
                    SendError(stream, 400);
                    return;
                }
               
                string method = request["method"];
                MyHashTable<string, string> param = parser.Form;
                string path = request["path"];               

                if (path.IndexOf("..") >= 0)
                {
                    SendError(stream, 400);
                    return;
                }

                if (path == string.Empty)
                {
                    path += "Index";
                }

                int index = path.LastIndexOf('.');
                string extension;
                string contentType;
                string response;

                if (index == -1)
                {

                    response = GetResponse(path, method, param, cookies);
                    WriteResponse(stream, response);
                }
                else
                {
                    extension = path.Substring(index);
                    contentType = GetContentType(extension);
                    WriteResponseFromFile(stream, path, extension, contentType);
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "метод Handle класса Client");
                SendError(stream, 500);   
                return;
            }
        }

         private static void WriteResponseFromFile(NetworkStream stream, string path, string extension, string contentType)
         {
#if DEBUG
            var filePath = Path.Combine(AssemblyDirectory, "..", "..", "files", path);
#else
            var filePath = Path.Combine(AssemblyDirectory, "files", path);
#endif

            if (!File.Exists(filePath))
             {
                 SendError(stream, 404);
                 return;
             }
            
             using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
             {
                 var headers = "HTTP/1.1 200 OK\nContent-Type: " + contentType + "\nContent-Length: " + fs.Length + "\n\n";
                 var headersBuffer = Encoding.ASCII.GetBytes(headers);
                 stream.Write(headersBuffer, 0, headersBuffer.Length);

                 var buffer = new byte[1024];

                 while (true)
                 {
                     var count = fs.Read(buffer, 0, buffer.Length);

                     if (count <= 0)
                         break;

                     stream.Write(buffer, 0, count);
                 }
             }
         }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private static void WriteResponse(NetworkStream stream, string response)
        {
            try
            {
                if (stream.CanWrite)
                {

                    byte[] buffer = Encoding.ASCII.GetBytes(response);
                    stream.Write(buffer, 0, buffer.Length);
                }
                else
                {
                    Console.WriteLine("Sorry.  You cannot write to this NetworkStream.");
                }
            }
            catch (Exception)
            {
                SendError(stream, 503);
                return;
            }

        }

        
        private static string GetResponse(string path, string method, MyHashTable<string, string> param, MyHashTable<string, string> cookies)
        {
            string sessionId;
            PageCreater pageCreater = PageCreater.Instance;
            if (cookies == null || !cookies.ContainsKey(" sessionId"))
            {
                sessionId = Guid.NewGuid().ToString();
            }
            else
            {
                sessionId = cookies[" sessionId"];
            }            

            Response response = pageCreater.PrepareResponse(path, method, param, sessionId);
            string html;
            int cod;
            string codStr;
            string location = response.Location;

            switch (response.StatusAnswer)
            {
                case TypeOfAnswer.Informational:
                    html = "<html><body><h1>Continue</h1></body></html>";
                    cod = 100;
                    codStr = "Continue";
                    return GetAnswerString(html, cod, codStr, sessionId);
                        
                case TypeOfAnswer.Success:
                    html = response.Content;
                    cod = 200;
                    codStr = "Ok";
                    return GetAnswerString(html, cod, codStr, sessionId);

                case TypeOfAnswer.Redirection:
                    return GetRedirectionAnswerString(response);
                        
                case TypeOfAnswer.ClientError:
                    html = "<html><body><h1>Not Found</h1></body></html>";
                    cod = 404;
                    codStr = "Not Found";
                    return GetAnswerString(html, cod, codStr, sessionId);
                    
                case TypeOfAnswer.ServerError:
                    html = "<html><body><h1>Internal Server Error</h1></body></html>";
                    cod = 500;
                    codStr = "Internal Server Error";
                    return GetAnswerString(html, cod, codStr, sessionId);                                     
                       
            }          

            return "";
        }


        private static string GetAnswerString(string html, int cod, string codStr, string sessionId)
        {
            StringBuilder answerString = new StringBuilder();
            answerString.Append("HTTP/1.1").Append(cod).Append(codStr);
            answerString.Append(Environment.NewLine);            
            answerString.Append("Content-type: text/html");
            answerString.Append(Environment.NewLine);
            answerString.Append("Content-Length: ");
            answerString.Append(html.Length.ToString());
            answerString.Append(Environment.NewLine);
            answerString.Append("Set-Cookie: ");
            answerString.Append("sessionId=").Append(sessionId);
            answerString.Append(Environment.NewLine);
            answerString.Append(Environment.NewLine);
            answerString.Append(html);

            return answerString.ToString();
        }

        private static string GetRedirectionAnswerString(Response rsp)
        {
            StringBuilder answerString = new StringBuilder();
            answerString.Append("HTTP/1.1  303 See Other ");
            answerString.Append(Environment.NewLine);
            answerString.Append("Location: ").Append(rsp.Location);
            answerString.Append(Environment.NewLine);

            if (rsp.Cookie != null)
            {
                foreach (var item in rsp.Cookie)
                {
                    answerString.Append("Set-Cookie: ");
                    answerString.Append(item.Key).Append("=").Append(item.Value);
                    answerString.Append(Environment.NewLine);
                }
            }

            return answerString.ToString();
        }

        private static string GetContentType(string extension)
        {
            string contentType = "";

            switch (extension)
            {
                case "":
                case ".htm":
                case ".html":
                    contentType = "text/html";
                    break;
                case ".css":
                    contentType = "text/css";
                    break;
                case ".js":
                    contentType = "text/javascript";
                    break;
                case ".jpg":
                    contentType = "image/jpeg";
                    break;
                case ".jpeg":
                case ".png":
                case ".gif":
                    contentType = "image/" + extension.Substring(1);
                    break;
                default:
                    if (extension.Length > 1)
                    {
                        contentType = "application/" + extension.Substring(1);
                    }
                    else
                    {
                        contentType = "application/unknown";
                    }
                    break;
            }

            return contentType;
        }

        private static string GetRequest(NetworkStream stream)
        {
            string request = "";
            var buffer = new byte[1024];

            int count;
            while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                request += Encoding.ASCII.GetString(buffer, 0, count);
                if (request.IndexOf("\r\n\r\n") >= 0 || request.Length > 4096)
                {
                    break;
                }
            }
            
            Console.WriteLine(request);
            return request;
        }

        private static void SendError(NetworkStream stream, int errorCode)
        {
            var codeStr = errorCode.ToString() + " " + ((HttpStatusCode)errorCode).ToString();
            var html = "<html><body><h1>" + codeStr + "</h1></body></html>";
            var str = "HTTP/1.1 " + codeStr + "\nContent-type: text/html\nContent-Length:" + html.Length.ToString() + "\n\n" + html;

            var buffer = Encoding.ASCII.GetBytes(str);

            stream.Write(buffer, 0, buffer.Length);
        }

   
    }
}
