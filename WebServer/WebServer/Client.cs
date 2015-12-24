using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace WebServer
{
    static class Client
    {
        public static void Handle(TcpClient client)
        {
            var stream = client.GetStream();

            try
            {
                var request = GetRequest(stream);

                var reqMatch = Regex.Match(request, @"^\w+\s+([^\s\?]+)[^\s]*\s+HTTP/.*|");

                if (reqMatch == Match.Empty)
                {
                    SendError(stream, 400);
                    return;
                }

                var requestUri = reqMatch.Groups[1].Value;
                requestUri = Uri.UnescapeDataString(requestUri);

                if (requestUri.IndexOf("..") >= 0)
                {
                    SendError(stream, 400);
                    return;
                }

                WriteResponse(stream, requestUri);
            }
            catch (Exception)
            {
                SendError(stream, 500);
                return;
            }
        }

        private static void WriteResponse(NetworkStream stream, string requestUri)
        {
            if (requestUri.EndsWith("/"))
            {
                requestUri += "index.html";
            }

            var filePath = "d://www/" + requestUri;

            if (!File.Exists(filePath))
            {
                SendError(stream, 404);
                return;
            }

            var extension = requestUri.Substring(requestUri.LastIndexOf('.'));
            var contentType = GetContentType(extension);

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

        private static string GetContentType(string extension)
        {
            string contentType = "";

            switch (extension)
            {
                case ".htm":
                case ".html":
                    contentType = "text/html";
                    break;
                case ".css":
                    contentType = "text/stylesheet";
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
