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
            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateManager", errors);
            
            if (errors != null && errors.Count > 0)
            {
                htmlForm.AddInput("name", form["name"], InputType.text);
                htmlForm.AddInput("surname", form["surname"], InputType.text);
                htmlForm.AddInput("address", form["address"], InputType.text);
                htmlForm.AddInput("phone", form["phone"], InputType.text);
                htmlForm.AddInput("login", form["login"], InputType.text);
                htmlForm.AddInput("password", form["password"], InputType.text);
               // htmlForm.AddTag("",form["h1"]);
                
            }
            else
            {
                htmlForm.AddInput("name", "", InputType.text);
                htmlForm.AddInput("surname", "", InputType.text);
                htmlForm.AddInput("address", "", InputType.text);
                htmlForm.AddInput("phone", "", InputType.text);
                htmlForm.AddInput("login", "", InputType.text);
                htmlForm.AddInput("password", "", InputType.text);
                htmlForm.AddTag(new HtmlTag("h1", "hello"));//-----------
                //.SetAdditionalAttributes("style", "color: green");

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
                ManagerServise ms = new ManagerServise("manager.txt");                
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
