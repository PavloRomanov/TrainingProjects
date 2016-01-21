﻿using System;
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
            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateManager", errors);

            MyList<string> options = new MyList<string>();
            options.Add("1 years");
            options.Add("3 years");
            options.Add("5 years");
            options.Add("more 5 years");



            if (errors != null && errors.Count > 0)
            {
                htmlForm.AddInput("Name", form["name"], InputType.text);
                htmlForm.AddInput("Surname", form["surname"], InputType.text);
                htmlForm.AddInput("Address", form["address"], InputType.text);
                htmlForm.AddInput("Phone", form["phone"], InputType.text);
                htmlForm.AddInput("Login", form["login"], InputType.text);
                htmlForm.AddInput("Password", form["password"], InputType.text);
                htmlForm.AddTag(new TagSelect ("","", options));//?

            }
            else
            {
                htmlForm.AddInput("Name", "", InputType.text);
                htmlForm.AddInput("Surname", "", InputType.text);              
                htmlForm.AddInput("Address", "", InputType.text);
                htmlForm.AddInput("Phone", "", InputType.text);
                htmlForm.AddInput("Login", "", InputType.text);
                htmlForm.AddInput("Password", "", InputType.text);
                htmlForm.AddTag(new HtmlTag("p", "WorkExperience:")).SetAdditionalAttributes("style", "color: green");
                htmlForm.AddTag(new TagSelect( "", "experience", options));

            }
            StringBuilder body = new StringBuilder("<body bgcolor='#adff2f'>");
            body.Append(Environment.NewLine);
            body.Append("<h1>Create Manager</h1>");
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
                Manager manager = new Manager(Guid.NewGuid(), form["name"], form["surname"], form["address"], form["phone"], form["login"], form["password"]);
                ManagerService ms = new ManagerService("manager.txt");
                manager.Work = (WorkExperience)Convert.ToInt32(form["experience"]);
                ms.Add(manager);
            }
            catch (Exception ex)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                Console.WriteLine(ex.Message);
                return response;
            }

            response = new Response("", TypeOfAnswer.Redirection, "ManagersList");

            return response;
        }
    }
}
