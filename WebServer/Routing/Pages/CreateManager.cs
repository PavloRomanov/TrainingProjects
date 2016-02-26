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

        protected override string AddBody(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            HtmlForm htmlForm = new HtmlForm(AllRequestMethods.RequestMethod.POST, "CreateManager", errors);
            htmlForm.SetAttribut("novalidate", "novalidate");
            if (errors != null && errors.Count > 0)
            {
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Name: ")
                 .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "name", form["name"]))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required");
                if (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                       .SetAttribut("id", "forname");
                }
                else
                { htmlForm.AddTag("span").SetAttribut("id", "forname"); }
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Surname: ")
                 .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "surname", form["surname"]))
                 .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required");
                if (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                     .SetAttribut("id", "forsurname");
                }
                else
                { htmlForm.AddTag("span").SetAttribut("id", "forsurname"); }

                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Address: ")
                 .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "address", form["address"]))
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("placeholder", "max length of 50 characters")
                    .SetAttribut("required", "required");
                if (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                     .SetAttribut("id", "foraddress");
                }
                else
                { htmlForm.AddTag("span").SetAttribut("id", "foraddress"); }
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Phone: ")
                 .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "phone", form["phone"]))
                    .SetAttribut("placeholder", "000-000-00-00")
                    .SetAttribut("required", "required");
                if (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                     .SetAttribut("id", "forphone");
                }
                else
                { htmlForm.AddTag("span").SetAttribut("id", "forphone"); }
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Login: ")
                 .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "login", form["login"]))
                    .SetAttribut("maxlength", "10")
                    .SetAttribut("placeholder", "max length of 10 characters")
                    .SetAttribut("required", "required");
                if (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                     .SetAttribut("id", "forlogin");
                }
                else
                { htmlForm.AddTag("span").SetAttribut("id", "forlogin"); }
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Password: ")
                 .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Password, "password", form["password"]))
                    .SetAttribut("maxlength", "10")
                    .SetAttribut("placeholder", "max length of 10 characters")
                    .SetAttribut("required", "required");
                if (errors.ContainsKey("name"))
                {
                    htmlForm.AddTag("span", errors["name"])
                       .SetAttribut("id", "forpassword");
                }
                else
                { htmlForm.AddTag("span").SetAttribut("id", "forpassword"); }
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "WorkExperience: ")
                     .SetAttribut("class", "lable");
                // ------------------------------------------------------------------------------

                HtmlBaseTag selectWork = htmlForm.AddTag("select").SetAttribut("name", "experience")
                     .SetAttribut("class", "select")
                     .SetAttribut("size", "1");
                foreach (KeyValuePair<StageExperience.WorkExperience, int> element in StageExperience.GetALL())
                {

                    if (element.Key.Equals(form["experience"]))
                    {
                        selectWork.AddTag("option", element.Key.ToString())
                           .SetAttribut("selected")
                           .SetAttribut("value", element.Value.ToString());
                    }
                    else
                    {
                        selectWork.AddTag("option", element.Key.ToString())
                           .SetAttribut("value", element.Value.ToString());
                    }
                }
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Reset, "Reset", "Clin"))
                    .SetAttribut("class", "buttonclin");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Submit, "Submit", "Submit"))
                    .SetAttribut("class", "buttonsubmit");
                htmlForm.AddTag("br");
            }
            else
            {
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Name: ")
                     .SetAttribut("class", "lable");
                htmlForm.AddTag((new HtmlInput(AllTypeInputcs.InputType.Text, "name", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters"))
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forname");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Surname: ")
                     .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "surname", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forsurname");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Address: ")
                 .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "address", ""))
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("placeholder", "max length of 50 characters")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "foraddress");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Phone: ")
               .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "phone", ""))
                    .SetAttribut("placeholder", "000-000-00-00")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forphone");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Login: ")
                 .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "login", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forlogin");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "Password: ")
                 .SetAttribut("class", "lable");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Password, "password", ""))
                    .SetAttribut("maxlength", "10")
                    .SetAttribut("placeholder", "max length of 10 characters")
                    .SetAttribut("required", "required");
                htmlForm.AddTag("span").SetAttribut("id", "forpassword");
                htmlForm.AddTag("br");
                htmlForm.AddTag("lable", "WorkExperience: ")
                 .SetAttribut("class", "lable");
                HtmlBaseTag selectWork = htmlForm.AddTag("select").SetAttribut("name", "experience")
                   .SetAttribut("class", "select")
                   .SetAttribut("size", "1");
                foreach (KeyValuePair<StageExperience.WorkExperience, int> element in StageExperience.GetALL())
                {
                    selectWork.AddTag("option", element.Key.ToString())
                       .SetAttribut("value", element.Value.ToString());

                }
                htmlForm.AddTag("br");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Reset, "Reset", "Clin"))
                    .SetAttribut("class", "buttonclin");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Submit, "Submit", "Submit"))
                    .SetAttribut("class", "buttonsubmit");
                htmlForm.AddTag("br");
            }

            StringBuilder body = new StringBuilder();
            body.Append(Environment.NewLine);
            body.Append(htmlForm.ToString(errors));
            body.Append(Environment.NewLine);
            return body.ToString();
        }

        public override Response Post(IDictionary<string, string> form, string sessionId = null)
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
                    manager.Work = (StageExperience.WorkExperience)Convert.ToInt32(form["experience"]);
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
            func.Append("<script src='client.js'>").Append("</script>");
            return func.ToString();
        }
    }
}