using System;
using System.Text;
using Model.Entity;
using Model.Servise;
using Routing.Pages.Helpers;
using System.Collections.Generic;

namespace Routing.Pages
{
    public class CreateClient : BasePage
    {
        protected override string Title { get { return "Create Client"; } }

        protected override string AddBody(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {          
            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateClient", errors);
            htmlForm.SetAttribut("novalidate", "novalidate");


            if(errors != null && errors.Count > 0)
            {
                HtmlBaseTag div1 = htmlForm.AddTag("div").SetAttribut("class", "row");
                HtmlBaseTag divLabel1 = div1.AddTag("div").SetAttribut("class", "forlabel");
                HtmlBaseTag divInput1 = div1.AddTag("div").SetAttribut("class", "forinput");
                divLabel1.AddTag("lable", "Name :");
                
                div1.AddTag(new HtmlInput(InputType.Text, "name", form["name"]))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid('name')");

                if (errors.ContainsKey("name")) div1.AddTag("span", errors["name"]).SetAttribut("id", "1");
                else div1.AddTag("span").SetAttribut("id", "1");

                div1.AddTag("br");

                HtmlBaseTag div2 = htmlForm.AddTag("div");
                div2.AddTag("lable", "Surname :");
                div2.AddTag("br");
                div2.AddTag(new HtmlInput(InputType.Text, "surname", form["surname"]))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid('surname')");
                
                if (errors.ContainsKey("surname")) div2.AddTag("span", errors["surname"]).SetAttribut("id", "2");
                else div2.AddTag("span").SetAttribut("id", "forsurname");

                div2.AddTag("br");

                HtmlBaseTag div3 = htmlForm.AddTag("div");
                div3.AddTag("lable", "Address :");
                div3.AddTag("br");
                div3.AddTag(new HtmlInput(InputType.Text, "address", form["address"]))
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("placeholder", "max length of 50 characters");

                if (errors.ContainsKey("address")) div3.AddTag("span", errors["address"]).SetAttribut("id", "3");                
                else div3.AddTag("span").SetAttribut("id", "foraddress");

                div3.AddTag("br");

                HtmlBaseTag div4 = htmlForm.AddTag("div");
                div4.AddTag("lable", "Phone :");
                div4.AddTag("br");
                div4.AddTag(new HtmlInput(InputType.Text, "phone", form["phone"]))
                    .SetAttribut("placeholder", "000-000-00-00")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid('phone')");

                if (errors.ContainsKey("phone")) div4.AddTag("span", errors["phone"]).SetAttribut("id", "4");
                else div4.AddTag("span").SetAttribut("id", "forphone");

                div4.AddTag("br");

                HtmlBaseTag div5 = htmlForm.AddTag("div");
                div5.AddTag(new HtmlInput(InputType.Reset, "Reset", "Clin"));
                div5.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit"));                
            }
            else
            {
                HtmlBaseTag div1 = htmlForm.AddTag("div");
                div1.AddTag("lable", "Name :");
                div1.AddTag("br");
                div1.AddTag(new HtmlInput(InputType.Text, "name", "" ))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid(this)");
                div1.AddTag("span").SetAttribut("id", "forname");
                div1.AddTag("br");

                HtmlBaseTag div2 = htmlForm.AddTag("div");
                div2.AddTag("lable", "Surname :");
                div2.AddTag("br");
                div2.AddTag(new HtmlInput(InputType.Text, "surname", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid(this)");
                div2.AddTag("span").SetAttribut("id", "forsurname");
                div2.AddTag("br");

                HtmlBaseTag div3 = htmlForm.AddTag("div");
                div3.AddTag("lable", "Address :");
                div3.AddTag("br");
                div3.AddTag(new HtmlInput(InputType.Text, "address", ""))
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("placeholder", "max length of 50 characters");
                div3.AddTag("span").SetAttribut("id", "foraddress");
                div3.AddTag("br");

                HtmlBaseTag div4 = htmlForm.AddTag("div");
                div4.AddTag("lable", "Phone :");
                div4.AddTag("br");
                div4.AddTag(new HtmlInput(InputType.Text, "phone", ""))
                    .SetAttribut("placeholder", "000-000-00-00")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid(this)");
                div4.AddTag("span").SetAttribut("id", "forphone");
                div4.AddTag("br");

                HtmlBaseTag div5 = htmlForm.AddTag("div");
                div5.AddTag(new HtmlInput(InputType.Reset, "Reset", "Clin"));
                div5.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit"));
                div5.AddTag(new HtmlInput(InputType.Button, "Click", "Click"))
                    .SetAttribut("onclick", "writeText()");
            }
            

            StringBuilder body = new StringBuilder();
            body.Append("<p id='ppp'></p>");
            body.Append(Environment.NewLine);
            body.Append(AddGreeting(sessionId));
            body.Append(Environment.NewLine);
            body.Append("<h1>Create Client</h1>");
            body.Append(Environment.NewLine);           
            body.Append(htmlForm.ToString(errors));
            body.Append(Environment.NewLine);                    

            return body.ToString();
        }


        public override Response Post(IDictionary<string, string> form, string sessionId = null)
        {
            ValidationHelper vh = new ValidationHelper();
            IDictionary<string, string> errors = new Dictionary<string, string>();

            if (!vh.LikeName(form["name"]))
            {
               errors.Add("name", "Invalid name!");
                                
            }
            if (!vh.LikeName(form["surname"]))
            {
                errors.Add("surname", "Invalid surname!");
            }
            if (!vh.LikePhoneNumber(form["phone"]))
            {
                errors.Add("phone", "Invalid phone!");
            }
            if (!vh.LikeAddress(form["address"]))
            {
                errors.Add("address", "Invalid address!");
            }
           
            if(errors.Count == 0)
            {
                try
                {
                    Client client = new Client(Guid.NewGuid(), form["name"], form["surname"], form["address"], form["phone"]);
                    ClientServiсe cs = new ClientServiсe("client.txt");
                    cs.Add(client);
                    
                    return new Response("", TypeOfAnswer.Redirection, "ClientsList");
                }
                catch (Exception)
                {
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
            StringBuilder script = new StringBuilder("<script src=")
                .Append("JavaScriptForClient.js").Append("></script>");

            return script.ToString();           
        }
    }
}
