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

        protected override string Title { get { return "Form's List"; } }

        protected override string AddBody(MyHashTable<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            StringBuilder body = new StringBuilder();
            try
            {

                FormServiсe aps = new FormServiсe("forms.txt");
                HashDictionary<Guid, Form> formclients = aps.GetAll();
              

                body.Append("<body bgcolor='#FFFF40\'>");
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
                body.Append("<th>Form of client</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Answer of client</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Controls</th>");
                body.Append(Environment.NewLine);

                body.Append("</tr>");

                ClientServiсe cs = new ClientServiсe("client.txt");
                int n = 1;
                foreach (var element in formclients)
                {
                    body.Append("<tr>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(n).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(cs.GetElement(element.Value.IdClient).Name +" "+ cs.GetElement(element.Value.IdClient).Surname).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(element.Value.F1.ToString()).Append("</td>"); ;
                    body.Append(Environment.NewLine);
                    //body.Append("<td>").Append(element.Value.F2.ToString()).Append("</td>"); ;
                    body.Append("<br>");
                    body.Append(Environment.NewLine);
                    /*body.Append("<br>").Append(element.Value.F3.ToString());
                    body.Append(Environment.NewLine);
                    body.Append("<br>").Append(element.Value.F4.ToString());
                    body.Append(Environment.NewLine);
                    body.Append("<br>").Append(element.Value.F5.ToString()).Append("</td>");*/
                    body.Append(Environment.NewLine);

                    body.Append("<td>").Append(element.Value.Answer1.ToString()).Append("</td>");
                    body.Append(Environment.NewLine);
                   // body.Append("<td>").Append(element.Value.Answer2.ToString()).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td><a href='ViewForm?id=").Append(element.Key).Append("'>View</a>");
                    body.Append("<a href='DeleteForm?id=").Append(element.Key).Append("'>Delete</a></td>");
                    body.Append(Environment.NewLine);
                    body.Append("<tr>");
                    n++;
                }

                body.Append("</table>");

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

        public override Response Post(MyHashTable<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }

    }
}

