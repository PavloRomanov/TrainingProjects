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
    public class ViewForm: BasePage   
{
        protected override string AddBody(MyHashTable<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            Response response;
            StringBuilder body = new StringBuilder("<body bgcolor='#ff8c00'>");
            try
            {
                FormServiсe fs = new FormServiсe("forms.txt");
                Guid id = new Guid(form["id"]);

                Form formclient = fs.GetElement(id);
                ClientServiсe cs = new ClientServiсe("client.txt");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Name client:</b>").Append(cs.GetElement(formclient.IdClient).Name+ " "+ cs.GetElement(formclient.IdClient).Surname).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>FormClient:</b>");
                body.Append(Environment.NewLine);
                body.Append("<table width='100%' border='1' cellspacing='0' cellpadding='4'>");
                body.Append(Environment.NewLine);
                body.Append("<tr>");
                body.Append(Environment.NewLine);
                body.Append("<th>Number</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Question</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Answer</th>");
                body.Append(Environment.NewLine);
                body.Append("</tr>");
                var forms = fs.GetAll();
                int n = 1;
                foreach (var element in forms)
                {
                    body.Append("<tr>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(n).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(element.Value.FormClient.ToString()).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(element.Value.Answer1).Append("</td>");//?
                    body.Append(Environment.NewLine);
                    body.Append("</tr>");
                    n++;
                }

                body.Append("</table>");
                body.Append(Environment.NewLine);
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

