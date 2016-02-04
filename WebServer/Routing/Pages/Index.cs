using System;
using System.Text;

namespace Routing.Pages
{
    public class Index : IBasePage
    {
        public Response Get(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            StringBuilder page = new StringBuilder("<!DOCTYPE html>");
            page.Append(Environment.NewLine);
            page.Append("<html lang='en' xmlns='http://www.w3.org/1999/xhtml'>");
            page.Append(Environment.NewLine);
            page.Append("<head>");
            page.Append(Environment.NewLine);
            page.Append("<meta charset = UTF-8/>");
            page.Append(Environment.NewLine);
            page.Append("<link rel='stylesheet' href='TabStyle.css' type='text/css'/>");
            page.Append(Environment.NewLine);
            page.Append("<title>CMS - Home Page</title>");            
            page.Append(Environment.NewLine);
            page.Append("</head>");
            page.Append(Environment.NewLine);

            page.Append("<body>");
            page.Append(Environment.NewLine);

            page.Append("<div class='header'>");
            page.Append(Environment.NewLine);
            page.Append("<h1>Welcome to S&S!</h1>");
            page.Append(Environment.NewLine);
            page.Append("<div class='logo'>");
            page.Append(Environment.NewLine);
            page.Append("<img src='SSC.jpg' style='width: 100px; height; 100px; border: 0'>");
            page.Append(Environment.NewLine);
            page.Append("</div>");
            page.Append(Environment.NewLine);
            page.Append("</div>");
            page.Append(Environment.NewLine);

            page.Append("<div class='menu'>");
            page.Append(Environment.NewLine);
            page.Append("<ul>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='Index'>Home</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='ClientsList'>Clients</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='CreateClient'>Create Client</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='ManagersList'>Managers</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='CreateManager'>Create Manager</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='CreateAppeal'>Create Appeal</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='CreateForm'>Create Form</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='Contact'>Contacts</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='LogIn'>LogIn</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='LogOut'>LogOut</a></li>");
            page.Append(Environment.NewLine);
            page.Append("</ul>");
            page.Append(Environment.NewLine);
            page.Append("</div>");

            page.Append("<div class='content'>");
            page.Append(Environment.NewLine);
            page.Append("<p><h3 style=text-align:center>Here can be your advertising</h3></p>");
            page.Append(Environment.NewLine);
            page.Append("</div>");

            page.Append("<div class='footer'>");
            page.Append(Environment.NewLine);
            page.Append("<p>Svetlana&Serg Corporation <br>Kiev 2015</p>");
            page.Append(Environment.NewLine);
            page.Append("</div>");

            page.Append(Environment.NewLine);
            page.Append("</body>");

            page.Append(Environment.NewLine);
            page.Append("</html>");

            return new Response(page.ToString(), TypeOfAnswer.Success, "");
        }

       
        public Response Post(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }
    }
}
