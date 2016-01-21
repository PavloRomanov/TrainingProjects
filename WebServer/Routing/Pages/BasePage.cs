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
            header.Append("<html lang='en' xmlns='http://www.w3.org/1999/xhtml'>");
            header.Append(Environment.NewLine);
            header.Append("<head>");
            header.Append(Environment.NewLine);
            header.Append("<meta charset=UTF-8/>");
            
             header.Append(Environment.NewLine);
            header.Append("<title>");
            header.Append("CMS - ").Append(Title);
            header.Append("</title>");
            header.Append(Environment.NewLine);
            header.Append("</head>");
            header.Append(Environment.NewLine);
            header.Append("<body>");
            //============================================================================================
            header.Append("<header>");
            header.Append(Environment.NewLine);
            header.Append("<head>");
            header.Append(Environment.NewLine);
            header.Append("<link rel='stylesheet' href='/TabStyle.css' type='text/css'/>");
            header.Append(Environment.NewLine);
            header.Append("</head>");
            header.Append(Environment.NewLine);
            header.Append("<body>");//---------------------------------------------
            header.Append("<div class='header'>");
            header.Append(Environment.NewLine);
            header.Append("<h1><i>Welcome to S & S</i></h1>");
            header.Append(Environment.NewLine);
            header.Append("<div class='logo'>");
            header.Append(Environment.NewLine);
            header.Append("<img src ='SSC.jpg' style='width: 100px; height; 100px; border: 0'>").Append("</div>");
            header.Append(Environment.NewLine);
            header.Append("</div>");
            header.Append(Environment.NewLine);
            header.Append("<div class='menu'>");
            header.Append(Environment.NewLine);
            header.Append("<ul>");
            header.Append(Environment.NewLine);
            header.Append("<li><a href='Index.html'>Home</a></li>");
            header.Append(Environment.NewLine);
            header.Append("<li><a href='ClientsList'>ClientsList</a></li>");
            header.Append(Environment.NewLine);
            header.Append("<li><a href='CreateClient'>CreateClient</a></li>");
            header.Append(Environment.NewLine);
            header.Append("<li><a href='FormList'>FormList</a></li>");
            header.Append(Environment.NewLine);
            header.Append("<li><a href='CreateForm'>CreateForm</a></li>");
            header.Append(Environment.NewLine);
            header.Append("<li><a href ='AppealList'>AppealList</a></li>");
            header.Append(Environment.NewLine);
            header.Append("<li><a href='CreateAppeal'>CreateAppeal</a></li>");
            header.Append(Environment.NewLine);
            header.Append("<li><a href ='ManagersList'>ManagerList</a></li>");
            header.Append(Environment.NewLine);
            header.Append("<li><a href='CreateManager'>CreateManager</a></li>");
            header.Append(Environment.NewLine);
            header.Append("<li><a href='Contact.html'>Contacts</a></li>");
            header.Append(Environment.NewLine);
            header.Append("<li><a href='LogOut'><b>Entrance</b></a></li>");
            header.Append(Environment.NewLine);
            header.Append(" </ul>").Append("</div>");            
            header.Append(Environment.NewLine);
            header.Append("</header>");
            header.Append(Environment.NewLine);
            header.Append("</body>");//------------------------------------------------------------------
            header.Append(Environment.NewLine);


            return header.ToString();
        }

       protected string AddGreeting(MyHashTable<string, string> cookies)
        {
            StringBuilder greeting = new StringBuilder();
            if (cookies != null && cookies.ContainsKey(" sessionId"))
            {
                string key = cookies[" sessionId"];
                User user = Session.registerSessions[key];                
                greeting.Append("<div><h3>Hello ").Append(user.login).Append("</h3></div>");
                return greeting.ToString();
            }            
            return "";
        }

        protected abstract string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors = null);

        //protected abstract string AddForm();

        protected virtual string AddFooter(/*"<footer><p style='text-align:center; color:red;'> Svetlana&Serg Corporation<br>Kiev 2015</p></footer>"*/)
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
