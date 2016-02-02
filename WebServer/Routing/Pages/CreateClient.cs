using System;
using System.Text;
using CollectionLibrary;
using Model.Entity;
using Model.Servise;
using Routing.Pages.Helpers;
using System.Collections.Generic;

namespace Routing.Pages
{
    public class CreateClient : BasePage
    {
        protected override string Title { get { return "Create Client"; } }

        protected override string AddBody(MyHashTable<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {          
            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateClient", errors);
            if(errors != null && errors.Count > 0)
            {
                htmlForm.AddTag("lable", "Name :");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "name", form["name"]))
                    .SetAttribut("maxlength", "15");

                htmlForm.AddTag("lable", "Surname :");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "surname", form["surname"]))
                    .SetAttribut("maxlength", "15");

                htmlForm.AddTag("lable", "Address :");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "address", form["address"]))
                    .SetAttribut("maxlength", "50");

                htmlForm.AddTag("lable", "Phone :");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "phone", form["phone"]))
                    .SetAttribut("placeholder", "000-000-00-00");

                htmlForm.AddTag(new HtmlInput(InputType.Reset, "Reset", "Сlean"));
                htmlForm.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit"));
            }
            else
            {
                htmlForm.AddTag("lable", "Name :");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "name", "" ))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters");

                htmlForm.AddTag("lable", "Surname :");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "surname", ""))
                    .SetAttribut("maxlength", "15")
                    .SetAttribut("placeholder", "max length of 15 characters");

                htmlForm.AddTag("lable", "Address :");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "address", ""))
                    .SetAttribut("maxlength", "50")
                    .SetAttribut("placeholder", "max length of 50 characters");

                htmlForm.AddTag("lable", "Phone :");
                htmlForm.AddTag(new HtmlInput(InputType.Text, "phone", ""))
                    .SetAttribut("placeholder", "000-000-00-00");

            htmlForm.AddTag(new HtmlInput(InputType.Reset, "Reset", "Сlean"));
            htmlForm.AddTag(new HtmlInput(InputType.Submit, "Submit", "Submit"));
           }
            

            StringBuilder body = new StringBuilder();

            body.Append(AddGreeting(sessionId));
            body.Append(Environment.NewLine);
            body.Append("<h1>Create Client</h1>");
            body.Append(Environment.NewLine);           
            body.Append(htmlForm.ToString(errors));
            body.Append(Environment.NewLine);                    

            return body.ToString();
        }


        public override Response Post(MyHashTable<string, string> form, string sessionId = null)
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
        
    }
}
