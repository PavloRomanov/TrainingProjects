﻿using System;
using System.Collections.Generic;
using CollectionLibrary;

namespace Routing.Pages
{
    public class Response
    {
        private string content;
        private TypeOfAnswer statusAnswer;
        private string location = "";
        public MyHashTable<string, string> Cookie { get; set; }

        public Response(string answer, TypeOfAnswer statuc, string location)
        {
            this.content = answer;
            statusAnswer = statuc;
            this.location = location;
        }

        public string Content
        {
            get { return content; }
        }

        public TypeOfAnswer StatusAnswer
        {
            get { return statusAnswer; }
        }

        public string Location
        {
            get { return location; }
        }

    }

    public enum TypeOfAnswer
    {
        Informational = 100,
        Success = 200,
        Redirection = 300,
        ClientError = 400,
        ServerError = 500
    }
}