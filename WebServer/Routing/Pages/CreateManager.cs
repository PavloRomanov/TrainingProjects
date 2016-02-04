using System;
using Model.Entity;
using Model.Servise;
using System.Text;
using CollectionLibrary;
using Routing.Pages.Helpers;
using System.Collections.Generic;

namespace Routing.Pages
{
    public class CreateManager : BasePage
    {
        protected override string Title { get { return "Create Manager"; } }

        protected override string AddBody(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateManager", errors);

            CollectionLibrary.MyHashTable<string, string> options = new CollectionLibrary.MyHashTable<string, string>();
            options.Add("1", "1 years");
            options.Add("3", "3 years");
            options.Add("5", "5 years");
            options.Add("5...", "more 5 years");



            if (errors != null && errors.Count > 0)
            {
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Name: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "name", form["name"]));
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Surname: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "surname", form["surname"]));
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Address: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "address", form["address"]));
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Phone: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "phone", form["phone"]));
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Login: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "login", form["login"]));
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Password: ");
                htmlForm.AddTag(new HtmlInput(InputType.Password, "password", form["password"]));
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "WorkExperience: ");
                htmlForm.AddSelect("experience", options);
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(InputType.Reset, "Reset", "Clin"));
                htmlForm.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit"));

            }
            else
            {
                htmlForm.AddTag("p").SetAttribut("id","xxx");//==================
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Name: ");
                htmlForm.AddTag( (new HtmlInput(InputType.Text, "name", ""))                          
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters"));
                htmlForm.AddTag("span").SetAttribut("id", "1");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Surname: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "surname", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters");
                htmlForm.AddTag("span").SetAttribut("id", "2");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Address: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "address", ""))
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("placeholder", "max length of 50 characters");
                htmlForm.AddTag("span").SetAttribut("id", "3");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Phone: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "phone", ""))
                    .SetAttribut("placeholder", "000-000-00-00");
                htmlForm.AddTag("span").SetAttribut("id", "4");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Login: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "login", ""));
                htmlForm.AddTag("span").SetAttribut("id", "5");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Password: ");
                htmlForm.AddTag(new HtmlInput(InputType.Password, "password", ""))
                    .SetAttribut("minlength", "7")
                    .SetAttribut("placeholder", "min length of 7 characters");
                htmlForm.AddTag("span").SetAttribut("id", "6");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "WorkExperience: ");
                htmlForm.AddSelect("experience", options)
                    .SetAttribut("size", "1");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(InputType.Reset, "Reset", "Clin")).SetAttribut("onclick", "ChangeColor");
                htmlForm.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit")).SetAttribut("onclick", "ValidateForm");
            }

            StringBuilder body = new StringBuilder();
            body.Append(Environment.NewLine);
            body.Append("<h2>Create Manager</h2>");
            body.Append(Environment.NewLine);
            body.Append(htmlForm.ToString(errors));
            body.Append(Environment.NewLine);
            body.Append(AddScript());
            body.Append(Environment.NewLine);
            return body.ToString();
        }

        public override Response Post(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null)
        {
            ValidationHelper vh = new ValidationHelper();
            CollectionLibrary.MyHashTable<string, string> errors = new CollectionLibrary.MyHashTable<string, string>();

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
                    Console.WriteLine(ex.Message + "class  CreateManager  method POST");
                    return new Response("", TypeOfAnswer.ServerError, "");
                }
            }
            else
            {
                return this.Get(form, sessionId, errors);
            }

        }
        protected override string AddScript()
        {
            StringBuilder func = new StringBuilder("<script src='Scriptfooter.js'>");
            func.Append("</script>");
            func.Append(Environment.NewLine);
            func.Append("<script src='Scriptmanager.js'>").Append("</script>");
            return func.ToString();
        }
    }
}