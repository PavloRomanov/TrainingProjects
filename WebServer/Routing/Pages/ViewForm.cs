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
        public ViewForm(AbstractServiceFactory sf)
            :base(sf)
        {
        }

        protected override string AddBody(IDictionary<string, string> form, string sessionId = null,IDictionary<string, string> errors = null)
        {
            Response response;
            StringBuilder body = new StringBuilder("<h1>ViewForm</h1>");
            try
            {
                //FormServiсe fs = new FormServiсe("forms.txt");
                IFormService fs = serviceFactory.CreateFormService();
                Guid id = new Guid(form["id"]);

               // Form formclient = fs.GetElement(id);
                Form formclient = fs.GetElement(id);
                // ClientServiсe cs = new ClientServiсe("client.txt");
                IClientService cs = serviceFactory.CreateClientService();
                Client c = cs.GetElement(formclient.IdClient);

                body.Append(Environment.NewLine);
                body.Append("<p><b id='col'>Name client:  </b>").Append(c.Name + " " + c.Surname);
                body.Append(Environment.NewLine);
                body.Append("<p><b id='col'>FormClient:</b>");
                body.Append(Environment.NewLine);
                body.Append("<table width='100%' border='1' cellspacing='0' cellpadding='4'>");
                body.Append(Environment.NewLine);
                body.Append("<tr>");
                body.Append(Environment.NewLine);
                body.Append("<th id='col'>Number</th>");
                body.Append(Environment.NewLine);
                body.Append("<th id='col'>Questions</th>");
                body.Append(Environment.NewLine);
                body.Append("<th id='col'>Answers</th>");
                body.Append(Environment.NewLine);
                body.Append("<th id='col'>Comments</th>");
                body.Append(Environment.NewLine);
                body.Append("</tr>");
                var forms = fs.GetAll();
                //var forms = sfs.GetAll();
                int n = 1;
                foreach (var element in forms)
                {
                    body.Append("<tr>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(n).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(element.Value.F1);
                    body.Append("<br>");
                    body.Append(element.Value.F2);
                    body.Append("<br>");
                    body.Append(element.Value.F3.ToString());
                    body.Append("<br>");
                    body.Append(element.Value.F4.ToString());
                    body.Append("<br>");
                    body.Append(element.Value.F5.ToString());
                    body.Append("</td>").Append(Environment.NewLine);
                    body.Append("<td>").Append(element.Value.Answer1);
                    body.Append("<br>");
                    body.Append(element.Value.Answer2);
                    body.Append("<br>");
                    body.Append(element.Value.Answer3);
                    body.Append("<br>");
                    body.Append(element.Value.Answer4);
                    body.Append("<br>");
                    body.Append(element.Value.Answer5);
                    body.Append("</td>").Append(Environment.NewLine);
                    body.Append("<td>").Append(element.Value.Comment1);
                    body.Append("<br>");
                    body.Append(element.Value.Comment2);
                    body.Append("<br>");
                    body.Append(element.Value.Comment3);
                    body.Append("<br>");
                    body.Append(element.Value.Comment4);
                    body.Append("<br>");
                    body.Append(element.Value.Comment5);
                    body.Append("</td>").Append(Environment.NewLine);
                    body.Append("</tr>");
                    n++;
                }

                body.Append("</table>");
                body.Append("<br>");
                // ManagerService ms = new ManagerService("manager.txt");
                IManagerService ms = serviceFactory.CreateManagerService();
                Manager man = ms.GetElement(formclient.IdManager);
                body.Append(Environment.NewLine);
                body.Append("<p><b id='col'>Manager:  </b>").Append(man.Name + " " + man.Surname);
                body.Append(Environment.NewLine);
                body.Append("<script>");
                body.Append("function(){ document.getElementById('col').style.color ='black'; }");
                body.Append("</script>");
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

