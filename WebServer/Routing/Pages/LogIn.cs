﻿using System;
using System.Text;
using CollectionLibrary;
using Routing.Pages.Helpers;
using Model.Servise;
using Model.Entity;
using System.Configuration;
using System.Collections.Generic;


namespace Routing.Pages
{
    public class LogIn : BasePage
    {
        protected override string Title { get { return "Log In"; } }

        protected override string AddBody(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {

            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "LogIn", errors);
            if (errors != null && errors.Count > 0)
            {
                htmlForm.AddInput("login", form["login"], InputType.Text, "Enter login :");
                htmlForm.AddInput("password", form["password"], InputType.Password, "Enter password :");
                htmlForm.AddTag(new HtmlInput(InputType.Reset, "Clean", "Clean"));
                htmlForm.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit"));

            }
            else
            {
                htmlForm.AddInput("login", "admin", InputType.Text, "Enter login :");
                htmlForm.AddInput("password", "admin", InputType.Password, "Enter password :");
                htmlForm.AddTag(new HtmlInput(InputType.Reset, "Clean", "Clean"));
                htmlForm.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit"));
            }

            StringBuilder body = new StringBuilder("<body bgcolor='#5DCFC3'>");
            body.Append(Environment.NewLine);
            body.Append("<h1>Log In</h1>");
            body.Append(Environment.NewLine);
            body.Append(Environment.NewLine);

            body.Append(htmlForm.ToString(errors));

            body.Append(Environment.NewLine);

            return body.ToString();
        }

        public override Response Post(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null)
        {

            Response response;
            try
            {
                CollectionLibrary.IDictionary<string, string> errors = new CollectionLibrary.IDictionary<string, string>();
                ManagerService ms = new ManagerService("manager.txt");
                Manager manager;

                string value = ConfigurationManager.AppSettings["Admin"];
                Guid guid = new Guid("c32f3d67-26da-4cba-9595-8a9f0efa0e5b");

                if (form["password"] == value)
                {
                    manager = new Manager(guid, "admin", "admin", "", "911", "admin", "admin");
                }
                else
                {
                    manager = ms.GetElementByLogin(form["login"]);
                }
                    

                if (manager == null)
                {                    
                    errors.Add("login", "User with such login does not exist!");                    
                    response = this.Get(form, sessionId, errors);
                }
                    else if (manager.Password != form["password"])
                {
                    errors.Add("password", "Password is wrong!");
                    response = this.Get(form, sessionId, errors);
                }                    
                else
                {
                    response = new Response("", TypeOfAnswer.Redirection, "Index");
                    
                        if (sessionId == null)
                        sessionId = Guid.NewGuid().ToString();

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
