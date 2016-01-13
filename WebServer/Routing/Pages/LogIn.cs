﻿using System;
using System.Collections.Generic;
using System.Text;
using CollectionLibrary;
using Routing.Pages.Helpers;
using Model.Servise;
using Model.Entity;

namespace Routing.Pages
{
    public class LogIn : BasePage
    {
        protected override string Title { get { return "Log In"; } }

        protected override string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {

            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "LogIn", errors);
            if (errors != null && errors.Count > 0)
            {
                htmlForm.AddInput("login", form["login"], InputType.text);
                htmlForm.AddInput("password", form["password"], InputType.password);
                                
            }
            else
            {
                htmlForm.AddInput("login", "", InputType.text);
                htmlForm.AddInput("password", "", InputType.password);
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

        public override Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {

            Response response;
            try
            {
                MyHashTable<string, string> errors = new MyHashTable<string, string>();
                ManagerServise ms = new ManagerServise("manager.txt");
                Manager manager = ms.GetElementByLogin(form["login"]);

                if(manager == null)
                {                    
                    errors.Add("login", "User with such login does not exist!");                    
                    response = this.Get(form, cookies, errors);
                }
                else if(manager.Password != form["password"])
                {
                    errors.Add("password", "Password is wrong!");
                    response = this.Get(form, cookies, errors);
                }                    
                else
                {
                    response = new Response("", TypeOfAnswer.Redirection, "Index");
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