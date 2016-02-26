using System;
using System.Text;
using Routing.Pages.Helpers;
using CollectionLibrary;
using Model.Entity;
using Model.Servise;
using System.Collections.Generic;


namespace Routing.Pages
{
    public class UpdateClient : BasePage
    {
        protected override string Title { get { return "Update Client"; } }

        public override Response Post(IDictionary<string, string> form, string sessionId = null)
        {
            Response response;
            try
            {
                ClientServiсe cs = new ClientServiсe("client.txt");
                Guid id = new Guid(form["id"]);
                Client client = new Client(id, form["name"], form["surname"], form["address"], form["phone"]);
                //cs.Update(client);
                cs.UpdateClient(client);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);                
                response = new Response("", TypeOfAnswer.ServerError, "");
                return response;
            }

            response = new Response("", TypeOfAnswer.Redirection, "ClientsList");

            return response;
        }

        protected override string AddBody(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            Response response;
            
            try
            {
                ClientServiсe cs = new ClientServiсe("client.txt");
                Guid id = new Guid(form["id"]);

                //Client client = cs.GetElement(id);
                Client client = cs.GetClientById(id);

                HtmlForm htmlForm = new HtmlForm(AllRequestMethods.RequestMethod.POST, "UpdateClient", errors);
                htmlForm.SetAttribut("novalidate", "novalidate");
                htmlForm.AddTag(new HtmlInput(AllTypeInputcs.InputType.Hidden, "id", client.Id.ToString()));

                HtmlBaseTag div1 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel1 = div1.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput1 = div1.AddTag("div", null).SetAttribut("class", "forinput");
                divLabel1.AddTag("lable", "Name :");
                divInput1.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "name", client.Name))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid('name')");                
                divInput1.AddTag("span").SetAttribut("id", "forname");


                HtmlBaseTag div2 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel2 = div2.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput2 = div2.AddTag("div", null).SetAttribut("class", "forinput");
                divLabel2.AddTag("lable", "Surname :");
                divInput2.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "surname", client.Surname))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid(this)");
                divInput2.AddTag("span").SetAttribut("id", "forsurname");


                HtmlBaseTag div3 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel3 = div3.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput3 = div3.AddTag("div", null).SetAttribut("class", "forinput");
                divLabel3.AddTag("lable", "Address :");
                divInput3.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "address", client.Address))
                    .SetAttribut("maxlength", "50");
                div3.AddTag("span").SetAttribut("id", "foraddress");


                HtmlBaseTag div4 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel4 = div4.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput4 = div4.AddTag("div", null).SetAttribut("class", "forinput");
                divLabel4.AddTag("lable", "Phone :");
                divInput4.AddTag(new HtmlInput(AllTypeInputcs.InputType.Text, "phone", client.Phone))
                    .SetAttribut("required", "required")
                    .SetAttribut("onblur", "InputIsValid(this)");
                div4.AddTag("span").SetAttribut("id", "forphone");


                HtmlBaseTag div5 = htmlForm.AddTag("div", null).SetAttribut("class", "row");
                HtmlBaseTag divLabel5 = div5.AddTag("div", null).SetAttribut("class", "forlabel");
                HtmlBaseTag divInput5 = div5.AddTag("div", null).SetAttribut("class", "forinput");
                divInput5.AddTag(new HtmlInput(AllTypeInputcs.InputType.Reset, "Reset", "Clin")
                    .SetAttribut("class", "buttonsubmit"));
                divInput5.AddTag(new HtmlInput(AllTypeInputcs.InputType.Submit, "Submit", "Submit")
                    .SetAttribut("class", "buttonsubmit"));

                StringBuilder body = new StringBuilder(Environment.NewLine);
                body.Append(AddGreeting(sessionId));
                body.Append(Environment.NewLine);
                body.Append(htmlForm.ToString(errors));
                body.Append(Environment.NewLine);

                return body.ToString();
            }
            catch (Exception )
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                return "";
            }
        }
     
    }
}
