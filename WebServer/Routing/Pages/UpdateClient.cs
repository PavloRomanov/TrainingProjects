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

        public override Response Post(MyHashTable<string, string> form, string sessionId = null)
        {
            Response response;
            try
            {
                ClientServiсe cs = new ClientServiсe("client.txt");
                Guid id = new Guid(form["id"]);
                Client client = new Client(id, form["name"], form["surname"], form["address"], form["phone"]);
                cs.Update(client);
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

        protected override string AddBody(MyHashTable<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            Response response;
            
            try
            {
                ClientServiсe cs = new ClientServiсe("client.txt");
                Guid id = new Guid(form["id"]);

                Client client = cs.GetElement(id);

                HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "UpdateClient", errors);
                htmlForm.AddInput("id", client.Id.ToString(), InputType.Hidden);
                htmlForm.AddInput("name", "", InputType.Text);
                htmlForm.AddInput("surname", "", InputType.Text);
                htmlForm.AddInput("address", "", InputType.Text);
                htmlForm.AddInput("phone", "", InputType.Text);

                StringBuilder body = new StringBuilder("<body>");
                body.Append("<form method='POST' action='UpdateClient'>");
                body.Append(Environment.NewLine);

                body.Append(htmlForm.ToString());

                body.Append(Environment.NewLine);

                return body.ToString();
            }
            catch (Exception)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                return "";
            }
        }
     
    }
}
