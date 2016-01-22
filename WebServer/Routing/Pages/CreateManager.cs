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
                htmlForm.AddInput("name", form["name"], InputType.Text);
                htmlForm.AddInput("surname", form["surname"], InputType.Text);
                htmlForm.AddInput("address", form["address"], InputType.Text);
                htmlForm.AddInput("phone", form["phone"], InputType.Text);
                htmlForm.AddInput("login", form["login"], InputType.Text);
                htmlForm.AddInput("password", form["password"], InputType.Text);
                //htmlForm.AddTag(form["h1"]);
                
            }
            else
            {
                htmlForm.AddInput("Name", "", InputType.Text);
                htmlForm.AddInput("Surname", "", InputType.Text);              
                htmlForm.AddInput("Address", "", InputType.Text);
                htmlForm.AddInput("Phone", "", InputType.Text);
                htmlForm.AddInput("Login", "", InputType.Text);
                htmlForm.AddInput("Password", "", InputType.Text);
                htmlForm.AddTag(new HtmlTag("p", "WorkExperience:"));
                MyList<string> options = new MyList<string>();
                options.Add("1 years");
                options.Add("3 years");
                options.Add("5 years");
                options.Add("more 5 years");
                htmlForm.AddTag(new TagSelect( "", "experience", options));

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
