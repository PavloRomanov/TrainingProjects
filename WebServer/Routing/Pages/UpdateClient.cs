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

        public override Response Post(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null)
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

        protected override string AddBody(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            Response response;
            
            try
            {
                ClientServiсe cs = new ClientServiсe("client.txt");
                Guid id = new Guid(form["id"]);

                Client client = cs.GetElement(id);

                HtmlForm htmlForm = new HtmlForm(RequestMethod.POST, "UpdateClient", errors);
                htmlForm.AddTag(new HtmlInput(InputType.Hidden, "id", client.Id.ToString()));
                htmlForm.AddTag(new HtmlInput(InputType.Text, "name", ""));
                htmlForm.AddTag(new HtmlInput(InputType.Text, "surname", ""));
                htmlForm.AddTag(new HtmlInput(InputType.Text, "address", ""));
                htmlForm.AddTag(new HtmlInput(InputType.Text, "phone", ""));

                StringBuilder body = new StringBuilder();
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
