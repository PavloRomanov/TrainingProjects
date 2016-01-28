using System;
using CollectionLibrary;

namespace Routing
{
    public class RequestParser
    {
        private string requestString;
        private string startLine;
        private string requestURI;
        private string method;
        private string path;
        private string formParameters;        
        private string[] AllRequestLine;
        private MyHashTable<string, string> cookies;
        private MyHashTable<string, string> requeste;
        private MyHashTable<string, string> form;

        public string StartLine { get { return startLine; } }

        public string Path { get { return path; } }

        public string Method { get { return method; } }

        public MyHashTable<string, string> Form { get { return form; } }

        public MyHashTable<string, string> Cookies { get { return cookies; } }

        public RequestParser(string requestString)
        {
            this.requestString = requestString;
            AllRequestLine = requestString.Split(new char[] { '\n' }, StringSplitOptions.None);
            startLine = AllRequestLine[0];            
        }      

        public MyHashTable<string, string> Parse()
        {
            requeste = new MyHashTable<string, string>();

            method = startLine.Substring(0, AllRequestLine[0].IndexOf(' '));
            requeste.Add("method", method);

            requestURI = FetchRequestURI();
            path = FetchPath();
            requeste.Add("path", path);

            SplitRestParameters();

            GetForm();

            foreach (var param in form)
            {
                requeste.Add(param.Key, param.Value);
            }            

            return requeste;
        }


        #region methods for Parse

        private string FetchRequestURI()
        {
            int start = startLine.IndexOf(' ') + 2;
            int end = startLine.IndexOf("HTTP")-1;
            requestURI = startLine.Substring(start, (end - start));
            return requestURI;
        }

        private string FetchPath()  //yes
        {
            if (requestURI.Contains("?"))
            {
                path = requestURI.Substring(0, requestURI.IndexOf('?'));
            }
            else
            {
                path = requestURI;
            }
            return path;
        }

        private string FetchFormParameters()
        {
            if (method == "GET")
            {
                if (requestURI.Contains("?"))
                {
                    formParameters = requestURI.Substring(requestURI.IndexOf('?') + 1);                    
                }
                else
                {
                    formParameters = "";
                }
            }      
            else
            {
                formParameters = "";
                int length = AllRequestLine.Length;
                for (int i = 1; i < length; i++)
                {
                    if (AllRequestLine[i] == "\r")
                    {
                        formParameters += AllRequestLine[i + 1];
                        break;
                    }                    
                }
            }
            return formParameters;
        }

        private void SplitCookies()
        {
            cookies = new MyHashTable<string, string>();
            string cookiesString;
            if (requeste.ContainsKey("Cookie"))
            {
                cookiesString = requeste["Cookie"];                
                int separator;
                string key;
                string value;
                string[] AllCookies = cookiesString.Split(new char[] { ';' }, StringSplitOptions.None);
                int length = AllCookies.Length;
                for (int i = 0; i < length; i++)
                {                   
                    separator = AllCookies[i].IndexOf('=');
                    key = AllCookies[i].Substring(0, separator);
                    char[] charsToTrim = {'\r'};
                    value = AllCookies[i].Substring(separator + 1).Trim(charsToTrim);
                    cookies.Add(key, value);                   
                }
            }
            else
            {
                cookies = null;
            }            
        }

        private void GetForm()
        {
            form = new MyHashTable<string, string>();
            formParameters = FetchFormParameters();
            if (formParameters != "")
            {
                form = SplitFormParameters();
            }

            SplitCookies();

            if (cookies != null)
            {
                foreach(var param in cookies)
                {
                    form.Add(param.Key, param.Value);
                }
            }
        }

        private MyHashTable<string, string> SplitFormParameters()
        {
            if (formParameters != "" || formParameters != null)
            {
                form = new MyHashTable<string, string>();
                string[] parameters = formParameters.Split('&');
                string[] temp;
                foreach (var param in parameters)
                {
                    temp = param.Split('=');
                    form.Add(temp[0], temp[1]);
                }
                return form;
            }
            return null;
        }

        private void SplitRestParameters()
        {
            int length = AllRequestLine.Length;
            int separator;
            string key;
            string value;
            for (int i = 1; i < length - 1; i++)
            {
                if (AllRequestLine[i] == "\r" || AllRequestLine[i] == "")
                {
                    break;
                }
                else
                {
                    separator = AllRequestLine[i].IndexOf(':');
                    key = AllRequestLine[i].Substring(0, separator);
                    value = AllRequestLine[i].Substring(separator + 1);
                    requeste.Add(key, value);
                }
            }
        }

        #endregion


       


        public void ShouAllRequestLine()
        {
            foreach (var item in AllRequestLine)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowMessage()
        {
            foreach (var item in requeste)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }


    }
}
