﻿using System;
using System.Text;
using Routing.Pages.Helpers;
using Model.Servise;
using Model.Entity;
using System.Configuration;
using System.Collections.Generic;
using Model.Enum;

namespace Routing.Pages
{
    public class LogIn : BasePage
    {
        public LogIn(AbstractServiceFactory sf)
            :base(sf)
        {
        }

        protected override string Title { get { return "Log In"; } }

        protected override string AddBody(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {

            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "LogIn", errors);
            if (errors != null && errors.Count > 0)
            {
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Enter login :")
                     .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "login", form["login"]))
                    .SetAttribut("class", "inputtext");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Enter password :")
                     .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(InputType.Password, "password", form["password"]))
                    .SetAttribut("class", "inputtext");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(InputType.Reset, "Clean", "Clean"))
                    .SetAttribut("class", "buttonclin");
                htmlForm.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit"))
                    .SetAttribut("class", "buttonsubmit");
                htmlForm.AddTag("br");
            }
            else
            {
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Enter login :")
                    .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "login", "admin"));
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Enter password :")
                    .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(InputType.Password, "password", "admin"));
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(InputType.Reset, "Clean", "Clean"))
                     .SetAttribut("class", "buttonclin");
                htmlForm.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit"))
                     .SetAttribut("class", "buttonsubmit");
            }

            StringBuilder body = new StringBuilder("<br>");
         
            body.Append(htmlForm.ToString(errors));

            body.Append(Environment.NewLine);

            return body.ToString();
        }

        public override Response Post(IDictionary<string, string> form, string sessionId = null)
        {

            Response response;
            try
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                //ManagerService ms = new ManagerService("manager.txt");
                IManagerService ms = serviceFactory.CreateManagerService();
                Manager manager = null;

                string value = ConfigurationManager.AppSettings["Admin"];
                Guid guid = new Guid("c32f3d67-26da-4cba-9595-8a9f0efa0e5b");

                if (form["password"] == value)
                {
                    manager = new Manager(guid, "admin", "admin", (WorkExperience)1, "", "911", "admin", "admin");
                }
                else
                {                  
                    manager = ((SQLManagerService)ms).GetElementByLogin(form["login"]);
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
