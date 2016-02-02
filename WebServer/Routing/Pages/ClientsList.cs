using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;
using Model.Servise;
using Model.Entity;
namespace Routing.Pages
{
    class ClientsList : BasePage
    {
        protected override string Title { get { return "Client's List"; } }

        protected override string AddBody(MyHashTable<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {

            StringBuilder body = new StringBuilder();
            try
            {
                 ClientServiсe cs = new ClientServiсe("client.txt");
                 HashDictionary<Guid, Client> clients = cs.GetAll();

                body.Append("<body bgcolor='#FFFF40\'>");
                body.Append(Environment.NewLine);
                body.Append("<h1>List Client</h1>");
                body.Append(Environment.NewLine);                
                body.Append(Environment.NewLine);
                body.Append("<table width='100%' border='1' cellspacing='0' cellpadding='4'>");
                body.Append(Environment.NewLine);               
                body.Append("<tr>");
                body.Append(Environment.NewLine);
                body.Append("<th>Number</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Name</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Surname</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Address</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Phone</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>controls</th>");
                body.Append(Environment.NewLine);
                body.Append("</tr>");
                

                int n = 1;
                foreach (var client in clients)
                {
                    body.Append("<tr>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(n).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(client.Value.Name).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(client.Value.Surname).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(client.Value.Address).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(client.Value.Phone).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>");
                    body.Append("<a href='ViewClient?id=").Append(client.Key).Append("'>View</a>");
                    body.Append("<a href='UpdateClient?id=").Append(client.Key).Append("'>Update</a>");
                    body.Append("<a href='DeleteClient?id=").Append(client.Key).Append("'>Delete</a>");
                    body.Append("</td>");
                    body.Append(Environment.NewLine);                    
                    body.Append("</tr>");                   
                    n++;
                }

                body.Append("</table>");
                body.Append(Environment.NewLine);
                body.Append(Environment.NewLine);
                body.Append("<a href='CreateClient'> Create new client </a>");
                body.Append(Environment.NewLine);                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response response = new Response("", TypeOfAnswer.ServerError, "");
                return "";
            }
            
            return body.ToString();
        }

        public override Response Post(MyHashTable<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }     
    }
}
