using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CollectionLibrary;
using Routing;

namespace Routing.Pages
{
    public abstract class BasePage : IBasePage
    {        
        public BasePage ()
        {                    
        }

        protected virtual string Title { get { return string.Empty; } }

        protected virtual string Script { get { return string.Empty; } }

        public Response Get(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            StringBuilder answer = new StringBuilder();
            answer.Append(AddHeader());
            answer.Append(AddBody(form, sessionId, errors)); 
            answer.Append(AddFooter());            
            Response response = new Response(answer.ToString(), TypeOfAnswer.Success, "");
            return response;
        }

        public virtual Response Post(IDictionary<string, string> form, string sessionId = null)
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
            header.Append("<link rel='stylesheet' href='TabStyle.css' type='text/css'/>");
            header.Append(Environment.NewLine);
            header.Append("<title>");
            header.Append("CMS - ").Append(Title);
            header.Append("</title>");
            header.Append(Environment.NewLine);
            header.Append("</head>");
            header.Append(Environment.NewLine);
            header.Append("<body>");
            header.Append(Environment.NewLine);
            header.Append("<div class='container'>");
            header.Append(Environment.NewLine);
            header.Append("<div class='header'>");
            header.Append(Environment.NewLine);
            header.Append("<h1>Welcome to S&S</h1>");
            header.Append(Environment.NewLine);
            header.Append("<div class='row1'>");
            header.Append(Environment.NewLine);
            header.Append("<div class='logo'>");
            header.Append(Environment.NewLine);
            header.Append("<img src ='SSC.jpg' style='width: 100px; height; 100px; border: 0'>");
            header.Append("</div>");  //  logo is closed            
            header.Append(Environment.NewLine);
            header.Append(AddMenu());           
            header.Append(Environment.NewLine);
            header.Append("</div>");  // row1 is closed  
            header.Append(Environment.NewLine);
            header.Append("<div style=clear:both>");
            header.Append(Environment.NewLine);
            header.Append("<h2 style=text-align:center>").Append(Title).Append("</h2>");
            header.Append(Environment.NewLine);
            header.Append("</div>");
            header.Append(Environment.NewLine);
            header.Append("</div>");  //  header is closed
            header.Append(Environment.NewLine);
            header.Append("<div class='content'>");  

            return header.ToString();
        }

       protected string AddGreeting(string sessionId)
        {
            StringBuilder greeting = new StringBuilder();
            if (sessionId != null)
            {
                User user = Session.Instance[sessionId];
                if(user != null)
                {
                    greeting.Append("<div><h3>Hello ").Append(user.Name).Append("</h3></div>");
                    return greeting.ToString();
                }
            }            
            return "";
        }

        protected abstract string AddBody(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null);

       

        protected virtual string AddFooter()
        {
            StringBuilder footer = new StringBuilder(Environment.NewLine);
            footer.Append("</div>");  //  content is closed
            footer.Append(Environment.NewLine);
            footer.Append("<div class='footer'>");
            footer.Append(Environment.NewLine);
            footer.Append("<p>Svetlana&Serg Corporation <br>Kiev 2015</p>");
            footer.Append(Environment.NewLine);
            footer.Append("</div>");  //  footer is closed
            footer.Append(Environment.NewLine);
            footer.Append("</div>"); //  container is closed
            footer.Append(Environment.NewLine);
            footer.Append(AddScript());
            footer.Append(Environment.NewLine);
            footer.Append("</body>");
            footer.Append(Environment.NewLine);
            footer.Append("</html>");
            return footer.ToString();
        }

        protected virtual string AddScript()
        {            
            return "";
        }

        protected string AddMenu()
        {
            StringBuilder menu = new StringBuilder("<div class='menu'>");            
            menu.Append(Environment.NewLine);
            menu.Append("<ul>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href='Index'>Home</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href='ClientsList'>Clients List</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href='CreateClient'>Create Client</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href='FormList'>Form List</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href='CreateForm'>Create Form</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href ='AppealList'>Appea lList</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href='CreateAppeal'>Create Appeal</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href ='ManagersList'>Manager List</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href='CreateManager'>Create Manager</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href='Contact'>Contacts</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href='LogIn'>LogIn</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append("<li><a href='LogOut'>LogOut</a></li>");
            menu.Append(Environment.NewLine);
            menu.Append(" </ul>");
            menu.Append(Environment.NewLine);
            menu.Append("</div>");
            menu.Append(Environment.NewLine);

            return menu.ToString();
        }

    }
}
