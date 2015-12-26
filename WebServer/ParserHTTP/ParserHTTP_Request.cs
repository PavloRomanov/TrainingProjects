using System;
using System.Collections.Generic;
using CollectionLibrary;

namespace ParserHTTP
{
    public class ParserHTTP_Request
    {
        private string requestHTTP;
        private string startLine;
        private string headers;
        private string message;
        private MyHashTable<string, string> request;
       
        public ParserHTTP_Request(string request)
        {
            requestHTTP = request;
        }
    }
}
