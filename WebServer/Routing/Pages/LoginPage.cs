using System;
using System.Collections.Generic;
using System.Text;
using CollectionLibrary;
using Routing.Pages.Helpers;
using Model.Servise;
using Model.Entity;

namespace Routing.Pages
{
    public class LoginPage : BasePage
    {
        protected override string Title { get { return "Log In"; } }

        protected override string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {
            
            //HtmlForm htmlForm = new HtmlForm();
            StringBuilder body = new StringBuilder("");
            /*
            if(form != null && form.ContainsKey("message"))
                body.Append("<p>").Append(form["message"]).Append("</p>");            
            body.Append(Environment.NewLine);
            body.Append(htmlForm.BeginForm(RequestMethod.POST, "LoginPage"));
            body.Append(Environment.NewLine);
            body.Append(new HtmlInput("login").ToString()).Append("<br/>");
            body.Append(Environment.NewLine);
            body.Append(new HtmlInput("password", "", InputType.password).ToString()).Append("<br/>");
            body.Append(Environment.NewLine);
            body.Append(htmlForm.EndForm());
            */

            return body.ToString();
        }

        public override Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {

            Response response;
            try
            {
                ManagerServise ms = new ManagerServise("manager.txt");
                Manager manager = ms.GetElementByLogin(form["login"], form["password"]);

                if(manager == null)
                {
                    MyHashTable<string, string> content = new MyHashTable<string, string>();
                    content.Add("message", "Login or password was wrong!!!");                    
                    response = this.Get(content, cookies);
                }                    
                else
                {
                    response = new Response("", TypeOfAnswer.Redirection, "index.html");
                    response.Cookie = new MyHashTable<string, string>();
                    User user = new User(manager.Id.ToString(), manager.Name, manager.Surname);
                    Guid sessionId = Guid.NewGuid();
                    Session.Add(sessionId, user);
                    MyHashTable<Guid, User> register = Session.registerSessions;
                    response.Cookie.Add("sessionId", sessionId.ToString());                   
                }
                
            }
            catch(Exception ex)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                Console.WriteLine(ex.Message);
                return response;
            }

            return response;
        }
    }
}
