using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;
using Model.Entity;
using Model.Servise;

namespace Routing.Pages
{
    public class UpdateClient : BasePage
    {
        protected override string Title { get { return "Update Client"; } }

        public override Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
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

        protected override string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {
            Response response;
            StringBuilder body = new StringBuilder("<body>");
            try
            {
                ClientServiсe cs = new ClientServiсe("client.txt");
                Guid id = new Guid(form["id"]);

                Client client = cs.GetElement(id); 
                               
                body.Append("<form method='POST' action='UpdateClient'>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'hidden' name = 'id' value ='").Append(client.Id).Append("'/>");
                body.Append(Environment.NewLine);
                body.Append("<p>Name:</p>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'text' name = 'name' value = '").Append(client.Name).Append("'/>");
                body.Append(Environment.NewLine);
                body.Append("<p>Surname:</p>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'text' name = 'surname' value = '").Append(client.Surname).Append("'/>");
                body.Append(Environment.NewLine);
                body.Append("<p>Address:</p>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'text' name = 'address' value = '").Append(client.Address).Append("'/>"); 
                body.Append(Environment.NewLine);
                body.Append("<p>Phone:</p>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'text' name = 'phone'  value = '").Append(client.Phone).Append("'/>");
                body.Append(Environment.NewLine);
                body.Append("<input type = 'submit' value = 'Submit'/>");
                body.Append(Environment.NewLine);
                body.Append("</form>");
                
            }
            catch (Exception)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                return "";
            }

            return body.ToString();
        }

     
    }
}
