using System;
using System.Collections.Generic;


namespace Routing.Pages
{
    public class Response
    {
        private string content;
        private TypeOfAnswer statusAnswer;
        private string location = "";
        public IDictionary<string, string> Cookie { get; set; }
        public string SessionId { get; set; }

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
