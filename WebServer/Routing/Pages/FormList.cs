using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Routing.Pages;
using CollectionLibrary;
using Model.Servise;
using Model.Entity;

namespace Routing.Pages
{
    public class FormList: BasePage
    {
        public FormList(AbstractServiceFactory sf)
            :base(sf)
        {
        }

        protected override string Title { get { return "Form's List"; } }

        protected override string AddBody(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            StringBuilder body = new StringBuilder();
            try
            {

                //FormServiсe fs = new FormServiсe("forms.txt");
                IFormService fs = serviceFactory.CreateFormServise();
                Dictionary<Guid, Form> formclients = fs.GetAll();
              
                body.Append(Environment.NewLine);
                body.Append("<h1>List Forms</h1>");
                body.Append(Environment.NewLine);
                body.Append("<table width='100%' border='1' cellspacing='0' cellpadding='4'>");
                body.Append(Environment.NewLine);
                body.Append("<tr>");
                body.Append(Environment.NewLine);
                body.Append("<th>Number</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Name client</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Controls</th>");
                body.Append(Environment.NewLine);

                body.Append("</tr>");

                //ClientService cs = new ClientService("client.txt");
                IClientService cs = serviceFactory.CreateClientServise();

                int n = 1;
                foreach (var element in formclients)
                {
                    body.Append("<tr>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(n).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(cs.GetElement(element.Value.IdClient).Name +" "+ cs.GetElement(element.Value.IdClient).Surname).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td><a href='ViewForm?id=").Append(element.Key).Append("'>View</a>");
                    body.Append("<a href='DeleteForm?id=").Append(element.Key).Append("'>Delete</a></td>");
                    body.Append(Environment.NewLine);
                    body.Append("<tr>");
                    n++;
                }

                body.Append("</table>");
                body.Append(Environment.NewLine);
                body.Append("<a href='CreateForm'>   Create new form </a>");
                body.Append(Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response response = new Response("", TypeOfAnswer.ServerError, "");
                return "";
            }

            return body.ToString();
        }

        public override Response Post(IDictionary<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }

    }
}

