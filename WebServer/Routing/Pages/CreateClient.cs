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

        protected override string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {
            HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "CreateClient", errors);
            if(errors != null && errors.Count > 0)
            {
                htmlForm.AddInput("name", form["name"], InputType.text).SetAdditionalAttributes("maxlength", "5");
                htmlForm.AddInput("surname", form["surname"], InputType.text);
                htmlForm.AddInput("address", form["address"], InputType.text);
                htmlForm.AddInput("phone", form["phone"], InputType.text).SetAdditionalAttributes("placeholder", "000-000-00-00");
            }
            else
            {
                htmlForm.AddInput("name", "", InputType.text)
                    .SetAdditionalAttributes("maxlength", "15")
                    .SetAdditionalAttributes("placeholder", "max length of 15 characters");
                htmlForm.AddInput("surname", "", InputType.text)
                    .SetAdditionalAttributes("maxlength", "15")
                    .SetAdditionalAttributes("placeholder", "max length of 15 characters");
                htmlForm.AddInput("address", "", InputType.text)
                    .SetAdditionalAttributes("maxlength", "50")
                    .SetAdditionalAttributes("placeholder", "max length of 50 characters"); ;
                htmlForm.AddInput("phone", "", InputType.text).SetAdditionalAttributes("placeholder", "000-000-00-00");
            }
            

            StringBuilder body = new StringBuilder("<body bgcolor='#adff2f'>");        
            body.Append(Environment.NewLine);
            body.Append("<h1>Create Client</h1>");
            body.Append(Environment.NewLine);           
            body.Append(htmlForm.ToString());

            body.Append(Environment.NewLine);                    

            return body.ToString();
        }

        /*protected override string AddGreeting(MyHashTable<string, string> cookies)
        {
            StringBuilder greeting = new StringBuilder();
            if (cookies.ContainsKey("sessionId"))
            {
                User user = Session.registerSessions[new Guid(cookies["sessionId"])];
                greeting.Append("<h2>Hello ").Append(user.login).Append("</h2>");
                return greeting.ToString();
            }
            return "";
        }*/

        public override Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
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
                catch (Exception ex)
                {
                    return new Response("", TypeOfAnswer.ServerError, "");
                }
            }
            else
            {
                return this.Get(form, cookies, errors);
            } 
        }

        
    }
}
