using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;

namespace Routing.Pages
{
    public class Index : IBasePage
    {
        public Response Get(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors = null)
        {
            StringBuilder page = new StringBuilder("<!DOCTYPE html>");
            page.Append(Environment.NewLine);
            page.Append("<html>");
            page.Append(Environment.NewLine);
            page.Append("<head>");
            page.Append(Environment.NewLine);
            page.Append("<meta charset = UTF-8/>");
            page.Append(Environment.NewLine);
            page.Append("<link rel='stylesheet' href='TabStyle.css' type='text/css'/>");
            page.Append(Environment.NewLine);
            page.Append("<title>Home Page</title>");            
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
            page.Append("<li><a href='IndexPage'>Home</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='ClientsList'>Clients</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='CreateClient'>Create Client</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='ManagersList'>Managers</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='CreateManager'>Create Manager</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='Contact.html'>Contacts</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='LogIn'>LogIn</a></li>");
            page.Append(Environment.NewLine);
            page.Append("<li><a href='LogOut'>LogOut</a></li>");
            page.Append(Environment.NewLine);
            page.Append("</ul>");

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

            return new Response(page.ToString(), TypeOfAnswer.Success, "");
        }

       
        public Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {
            throw new NotImplementedException();
        }
    }
}
