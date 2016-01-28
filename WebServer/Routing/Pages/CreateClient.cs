using System;
using System.Text;
using CollectionLibrary;
using Model.Entity;
using Model.Servise;
using Routing.Pages.Helpers;

namespace Routing.Pages
{
    public class CreateClient : BasePage
    {
        protected override string Title { get { return "Create Client"; } }

        protected override string AddBody(MyHashTable<string, string> form, string sessionId = null, MyHashTable<string, string> errors = null)
        {          
            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateClient", errors);
            if(errors != null && errors.Count > 0)
            {
                htmlForm.AddInput("name", form["name"], InputType.Text).SetAttribut("maxlength", "5");
                htmlForm.AddInput("surname", form["surname"], InputType.Text);
                htmlForm.AddInput("address", form["address"], InputType.Text);
                htmlForm.AddInput("phone", form["phone"], InputType.Text).SetAttribut("placeholder", "000-000-00-00");
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
                htmlForm.AddInput("phone", "", InputType.Text).SetAttribut("placeholder", "000-000-00-00");
            }
            

            StringBuilder body = new StringBuilder();

            body.Append(AddGreeting(sessionId));
            body.Append(Environment.NewLine);
            body.Append("<h1>Create Client</h1>");
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
