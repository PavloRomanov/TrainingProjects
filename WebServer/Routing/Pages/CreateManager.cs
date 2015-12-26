using System;
using Model.Entity;
using Model.Servise;
using System.Text;
using CollectionLibrary;
using Routing.Pages.Helpers;

namespace Routing.Pages
{
    public class CreateManager : BasePage
    {
        protected override string Title { get { return "Create Manager"; } }

        protected override string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {
            StringBuilder body = new StringBuilder("<body bgcolor='#adff2f'>");
            /*body.Append(Environment.NewLine);
            body.Append("<h1>Create Manager</h1>");
            body.Append(Environment.NewLine);
            body.Append("<p style='text-align:right'><a href='index.html'><h3>Home</h3></a></p>");
            body.Append(Environment.NewLine);
            body.Append(Environment.NewLine);
            body.Append(HtmlForm.BeginForm(RequestMethod.POST, "CreateManager"));            
            body.Append(Environment.NewLine);
            body.Append("Name:<br/>");
            body.Append(Environment.NewLine);
            body.Append(new HtmlInput("name").ToString()).Append("<br/>");
            body.Append(Environment.NewLine);
            body.Append("Surname:<br/> ");
            body.Append(Environment.NewLine);
            body.Append(new HtmlInput("surname").ToString()).Append("<br/>");           
            body.Append(Environment.NewLine);
            body.Append("Login:<br/>");
            body.Append(Environment.NewLine);
            body.Append(new HtmlInput("login").ToString()).Append("<br/>");
            body.Append(Environment.NewLine);
            body.Append("Password:<br/>");
            body.Append(Environment.NewLine);
            body.Append(new HtmlInput("password", "", InputType.password).ToString()).Append("<br/>");
            body.Append(Environment.NewLine);
            body.Append(new HtmlInput("", "Clear", InputType.reset).ToString()).Append("<br/>");           
            body.Append(HtmlForm.EndForm());
            body.Append(Environment.NewLine);*/


            return body.ToString();
        }

        public override Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {
            Response response;
            try
            {
                Manager manager = new Manager(Guid.NewGuid(), form["name"], form["surname"], form["login"], form["password"]);
                ManagerServise ms = new ManagerServise("manager.txt");                
                ms.Add(manager);
            }
            catch (Exception ex)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                Console.WriteLine(ex.Message);
                return response;
            }

            response = new Response("", TypeOfAnswer.Redirection, "index.html");

            return response;
        }
    }
}
