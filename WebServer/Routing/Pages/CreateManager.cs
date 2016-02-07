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

        protected override string AddBody(IDictionary<string, string> form, string sessionId = null,IDictionary<string, string> errors = null)
        {
            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateManager", errors);
            htmlForm.SetAttribut("novalidate", "novalidate");
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("1", "1 years");
            options.Add("3", "3 years");
            options.Add("4", "5 years");
            options.Add("5", "more 5 years");

            if (errors != null && errors.Count > 0)
            {
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Name: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "name", form["name"]))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required");
                if (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                       .SetAttribut("id", "1");
                }
                else
                { htmlForm.AddTag("span").SetAttribut("id", "1"); }
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Surname: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "surname", form["surname"]))
                 .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required");
                if (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                       .SetAttribut("id", "2");
                }
                else
                { htmlForm.AddTag("span").SetAttribut("id", "2"); }

                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Address: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "address", form["address"]))
                     .SetAttribut("maxlength", "50")
                    .SetAttribut("placeholder", "max length of 50 characters")
                    .SetAttribut("required", "required");
                if  (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                     .SetAttribut("id", "3");
                }
                else
                {htmlForm.AddTag("span").SetAttribut("id", "3"); }
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Phone: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "phone", form["phone"]))
                    .SetAttribut("placeholder", "000-000-00-00")
                    .SetAttribut("required", "required");
                if (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                       .SetAttribut("id", "4");
                }
                else
                { htmlForm.AddTag("span").SetAttribut("id", "4"); }
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Login: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "login", form["login"]))
                    .SetAttribut("maxlength", "10")
                    .SetAttribut("placeholder", "max length of 10 characters")
                    .SetAttribut("required", "required");
                if (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                       .SetAttribut("id", "5");
                }
                else
                { htmlForm.AddTag("span").SetAttribut("id", "5"); }
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Password: ");
                htmlForm.AddTag(new HtmlInput(InputType.Password, "password", form["password"]))
                    .SetAttribut("minlength", "7")
                    .SetAttribut("placeholder", "min length of 7 characters")
                    .SetAttribut("required", "required");
                if (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                       .SetAttribut("id", "6");
                }
                else
                { htmlForm.AddTag("span").SetAttribut("id", "s6"); }
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "WorkExperience: ");
                htmlForm.AddTag(new HtmlSelect("experience", options));
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(InputType.Reset, "Reset", "Clin"));
                htmlForm.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit"));

            }
            else
            {
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Name: ");
                htmlForm.AddTag((new HtmlInput(InputType.Text, "name", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters"))
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "s1");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Surname: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "surname", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                     .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "s2");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Address: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "address", ""))
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("placeholder", "max length of 50 characters")
                     .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "s3");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Phone: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "phone", ""))
                    .SetAttribut("placeholder", "000-000-00-00")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "s4");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Login: ");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "login", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "s5");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Password: ");
                htmlForm.AddTag(new HtmlInput(InputType.Password, "password", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "s6");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "WorkExperience: ");
                htmlForm.AddTag(new HtmlSelect("experience", options))
                    .SetAttribut("size", "1");
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(InputType.Reset, "Reset", "Clin"));
                htmlForm.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit")).SetAttribut("onclick", " FormIsValid()");
            }

            StringBuilder body = new StringBuilder();
            body.Append(Environment.NewLine);
            body.Append("<h2>Create Manager</h2>");
            body.Append(Environment.NewLine);
            body.Append(htmlForm.ToString(errors));
            body.Append(Environment.NewLine);
            return body.ToString();
        }

        public override Response Post(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null)
        {
            ValidationHelper vh = new ValidationHelper();
            Dictionary<string, string> errors = new Dictionary<string, string>();

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
            StringBuilder func = new StringBuilder();
            func.Append(Environment.NewLine);
            func.Append("<script src='JavaScriptForManager.js'>").Append("</script>");
            return func.ToString();
        }
    }
}