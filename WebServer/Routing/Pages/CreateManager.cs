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

         protected override string AddBody(MyHashTable<string, string> form, string sessionId = null, MyHashTable<string, string> errors = null)
        {
            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateManager", errors);

            MyHashTable<string,string> options = new MyHashTable<string, string>();
            options.Add("1","1 years");
            options.Add("3","3 years");
            options.Add("5","5 years");
            options.Add("5...","more 5 years");



            if (errors != null && errors.Count > 0)
            {
                htmlForm.AddInput("name", form["name"], InputType.Text);
                htmlForm.AddInput("surname", form["surname"], InputType.Text);
                htmlForm.AddInput("address", form["address"], InputType.Text);
                htmlForm.AddInput("phone", form["phone"], InputType.Text);
                htmlForm.AddInput("login", form["login"], InputType.Text);
                htmlForm.AddInput("password", form["password"], InputType.Text);
                htmlForm.AddSelect("experience", options);//?

            }
            else
            {
                htmlForm.AddInput("name", "", InputType.Text)
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters");
                htmlForm.AddInput("surname", "", InputType.Text)
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters");
                htmlForm.AddInput("address", "", InputType.Text)
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("placeholder", "max length of 50 characters");
                htmlForm.AddInput("phone", "", InputType.Text)
                    .SetAttribut("placeholder", "000-000-00-00");
                htmlForm.AddInput("login", "", InputType.Text);
                htmlForm.AddInput("password", "", InputType.Text)
                    .SetAttribut("minlength", "7")
                    .SetAttribut("placeholder", "min length of 7 characters");
                htmlForm.AddTag("p", "workExperience:");
                htmlForm.AddSelect("experience", options)
                    .SetAttribut("size", "1");
            }
            StringBuilder body = new StringBuilder("<body bgcolor='#adff2f'>");
            body.Append(Environment.NewLine);
            body.Append("<h1>Create Manager</h1>");
            body.Append(Environment.NewLine);
            body.Append(htmlForm.ToString());
            body.Append(Environment.NewLine);

            return body.ToString();
        }

         public override Response Post(MyHashTable<string, string> form, string sessionId = null)
        {
            ValidationHelper vh = new ValidationHelper();
            MyHashTable<string, string> errors = new MyHashTable<string, string>();

            if (!vh.LikeName(form["name"]))
            {
                errors.Add("name", "Invalid name!");
            }
            if (!vh.LikeName(form["surname"]))
            {
                errors.Add("surname", "Invalid surname!");
            }
            if (!vh.LikeAddress(form["address"]))
            {
                errors.Add("address", "Invalid address!");
            }
            if (!vh.LikePhoneNumber(form["phone"]))
            {
                errors.Add("phone", "Invalid phone!");
            }
            if (!vh.LikeAddress(form["login"]))
            {
                errors.Add("login", "Invalid login!");
            }
            if (!vh.LikeAddress(form["password"]))
            {
                errors.Add("password", "Invalid password!");
            }


            if (errors.Count == 0)
            {

                try
                {
                    Manager manager = new Manager(Guid.NewGuid(), form["name"], form["surname"], form["address"], form["phone"], form["login"], form["password"]);
                    ManagerService ms = new ManagerService("manager.txt");
                    manager.Work = (WorkExperience)Convert.ToInt32(form["experience"]);
                    ms.Add(manager);
                    return new Response("", TypeOfAnswer.Redirection, "ManagersList");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return new Response("", TypeOfAnswer.ServerError, "");
                }

            }
            else
            {
                 return this.Get(form, sessionId, errors);
            }

        }
    }
}