using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;
using System.Net;

namespace Routing.Pages
{
    public abstract class BasePage : IBasePage
    {        
        public BasePage ()
        {                    
        }

        protected virtual string Title { get { return string.Empty; } }

        protected virtual string Script { get { return string.Empty; } }

        public Response Get(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors = null)
        {
            StringBuilder answer = new StringBuilder();
            answer.Append(AddHeader());
            answer.Append(AddBody(form, cookies, errors));
            answer.Append(AddFooter());            
            Response response = new Response(answer.ToString(), TypeOfAnswer.Success, "");
            return response;
        }

        public virtual Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {
            throw new NotSupportedException();
        } 
  
        protected virtual string AddHeader()
        {
            
            StringBuilder header = new StringBuilder("<!DOCTYPE html>");            
            header.Append(Environment.NewLine);
            header.Append("<html lang = 'en' xmlns = 'http://www.w3.org/1999/xhtml'>");
            header.Append(Environment.NewLine);
            header.Append("<head>");
            header.Append(Environment.NewLine);
            header.Append("<meta charset = UTF-8/>");
            
             header.Append(Environment.NewLine);
            header.Append("<title>");
            header.Append("CMS - ").Append(Title);
            header.Append("</title>");
            header.Append(Environment.NewLine);
            header.Append("</head>");
            header.Append(Environment.NewLine);
            header.Append("<body>");
            
            return header.ToString();
        }

        protected virtual string AddGreeting(MyHashTable<string, string> cookies)
        {
            StringBuilder greeting = new StringBuilder();
            if(cookies.ContainsKey("sessionId"))
            {
                User user = Session.registerSessions[new Guid(cookies["sessionId"])];
                greeting.Append("<h2>Hello ").Append(user.login).Append("</h2>");
                return greeting.ToString();
            }
            return "";
        }

        protected abstract string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors = null);

        //protected abstract string AddForm();

        protected virtual string AddFooter()
        {
            StringBuilder footer = new StringBuilder();
            footer.Append(Environment.NewLine);
            footer.Append("<script");
            footer.Append(" src='Scripts/").Append(Script).Append("'>");
            footer.Append("</ script >");
            footer.Append(Environment.NewLine);
            footer.Append("</body>");
            footer.Append(Environment.NewLine);
            footer.Append("</html>");
            return footer.ToString();
        }       
 
    }
}
