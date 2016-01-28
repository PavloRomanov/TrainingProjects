using System;
using System.Collections.Generic;
using System.Text;
using CollectionLibrary;
using Routing.Pages.Helpers;
using Model.Servise;
using Model.Entity;
using System.Configuration;

namespace Routing.Pages
{
    public class LogIn : BasePage
    {
        protected override string Title { get { return "Log In"; } }

        protected override string AddBody(MyHashTable<string, string> form, string sessionId = null, MyHashTable<string, string> errors = null)
        {

            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "LogIn", errors);
            if (errors != null && errors.Count > 0)
            {
                htmlForm.AddInput("login", form["login"], InputType.Text);
                htmlForm.AddInput("password", form["password"], InputType.Password);
                                
            }
            else
            {
                htmlForm.AddInput("login", "", InputType.Text);
                htmlForm.AddInput("password", "", InputType.Password);
            }

            StringBuilder body = new StringBuilder("<body bgcolor='#5DCFC3'>");
            body.Append(Environment.NewLine);
            body.Append("<h1>Log In</h1>");
            body.Append(Environment.NewLine);
            body.Append(Environment.NewLine);

            body.Append(htmlForm.ToString());

            body.Append(Environment.NewLine);

            return body.ToString();
        }

        public override Response Post(MyHashTable<string, string> form, string sessionId = null)
        {

            Response response;
            try
            {
                MyHashTable<string, string> errors = new MyHashTable<string, string>();
                ManagerService ms = new ManagerService("manager.txt");

                if (form["login"] == "admin")
                {
                    var adminPassword = ConfigurationManager.AppSettings["adminPassword"];
                    
                }

                Manager manager = ms.GetElementByLogin(form["login"]);

                if (manager == null)
                {                    
                    errors.Add("login", "User with such login does not exist!");                    
                    response = this.Get(form, sessionId, errors);
                }
                else if(manager.Password != form["password"])
                {
                    errors.Add("password", "Password is wrong!");
                    response = this.Get(form, sessionId, errors);
                }                    
                else
                {
                    response = new Response("", TypeOfAnswer.Redirection, "Index");
                    
                    //User user = new User();
                    //user.SetUser(manager.Id.ToString(), manager.Name, manager.Surname);

                    if(sessionId == null)
                        sessionId = Guid.NewGuid().ToString();

                    //Session.Instance[sessionId] = user;  // ERROR!!!! 
                    Session.Instance.RegisterSessions[sessionId].SetUser(manager.Id.ToString(), manager.Name, manager.Surname);     
                   
                    response.SessionId = sessionId;
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
