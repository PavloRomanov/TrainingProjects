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
            HtmlForm htmlForm = new HtmlForm(AllRequestMethods.RequestMethod.POST, "CreateClient", errors);
            htmlForm.SetAttribut("novalidate", "novalidate");


            if(errors != null && errors.Count > 0)
            {
                HtmlBaseTag div1 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel1 = div1.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput1 = div1.AddTag("div", null).SetAttribut("class", "forinput");                
                divLabel1.AddTag("lable", "Name :");
                divInput1.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "name", form["name"]))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid('name')");

                if (errors.ContainsKey("name")) divInput1.AddTag("span", errors["name"]).SetAttribut("id", "forname");
                else divInput1.AddTag("span").SetAttribut("id", "forname");


                HtmlBaseTag div2 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel2 = div2.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput2 = div2.AddTag("div", null).SetAttribut("class", "forinput");
                divLabel2.AddTag("lable", "Surname :");
                divInput2.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "surname", form["surname"]))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid(this)");

                if (errors.ContainsKey("surname")) divInput2.AddTag("span", errors["surname"]).SetAttribut("id", "forsurname");
                else divInput2.AddTag("span").SetAttribut("id", "forsurname");


                HtmlBaseTag div3 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel3 = div3.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput3 = div3.AddTag("div", null).SetAttribut("class", "forinput");
                divLabel3.AddTag("lable", "Address :");
                divInput3.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "address", form["address"]))
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("placeholder", "max length of 50 characters");

                if (errors.ContainsKey("address")) div3.AddTag("span", errors["address"]).SetAttribut("id", "foraddress");
                else div3.AddTag("span").SetAttribut("id", "foraddress");


                HtmlBaseTag div4 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel4 = div4.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput4 = div4.AddTag("div", null).SetAttribut("class", "forinput");
                divLabel4.AddTag("lable", "Phone :");
                divInput4.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "phone", form["phone"]))
                    .SetAttribut("placeholder", "000-000-00-00")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid(this)");

                if (errors.ContainsKey("phone")) div4.AddTag("span", errors["phone"]).SetAttribut("id", "forphone");
                else div4.AddTag("span").SetAttribut("id", "forphone");


                HtmlBaseTag div5 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel5 = div5.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput5 = div5.AddTag("div", null).SetAttribut("class", "forinput");
                divInput5.AddTag(new HtmlInput(AllTypeInputcs.InputType.Reset, "Reset", "Clin")
                     .SetAttribut("class", "buttonsubmit"));
                divInput5.AddTag(new HtmlInput(AllTypeInputcs.InputType.Submit, "Submit", "Submit")
                    .SetAttribut("class", "buttonsubmit"));

            }
            else
            {
                HtmlBaseTag div1 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel1 = div1.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput1 = div1.AddTag("div", null).SetAttribut("class", "forinput");
                divLabel1.AddTag("lable", "Name :");
                divInput1.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "name", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid(this)");
                divInput1.AddTag("span", null).SetAttribut("id", "forname");


                HtmlBaseTag div2 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel2 = div2.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput2 = div2.AddTag("div", null).SetAttribut("class", "forinput");
                divLabel2.AddTag("lable", "Surname :");                
                divInput2.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "surname", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid(this)");
                divInput2.AddTag("span").SetAttribut("id", "forsurname");

                
                HtmlBaseTag div3 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel3 = div3.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput3 = div3.AddTag("div", null).SetAttribut("class", "forinput");
                divLabel3.AddTag("lable", "Address :");
                divInput3.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "address", ""))
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("placeholder", "max length of 50 characters");
                divInput3.AddTag("span").SetAttribut("id", "foraddress");
               

                HtmlBaseTag div4 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel4 = div4.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput4 = div4.AddTag("div", null).SetAttribut("class", "forinput");
                divLabel4.AddTag("lable", "Phone :");
                divInput4.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "phone", ""))
                    .SetAttribut("placeholder", "000-000-00-00")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid(this)");
                divInput4.AddTag("span").SetAttribut("id", "forphone");
               

                HtmlBaseTag div5 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel5 = div5.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput5 = div5.AddTag("div", null).SetAttribut("class", "forinput");
                divInput5.AddTag(new HtmlInput(AllTypeInputcs.InputType.Reset, "Reset", "Clin")
                    .SetAttribut("class", "buttonsubmit"));
                divInput5.AddTag(new HtmlInput(AllTypeInputcs.InputType.Submit, "Submit", "Submit")
                    .SetAttribut("class", "buttonsubmit"));
            }
            

            StringBuilder body = new StringBuilder(Environment.NewLine);            
            body.Append(AddGreeting(sessionId));
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
                    //IServise<Client> cs = new ClientFileServise("client.txt");
                    ClientSQLService cs = new ClientSQLService("Clients");
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
                .Append("client.js").Append("></script>");

            return script.ToString();           
        }
    }
}
