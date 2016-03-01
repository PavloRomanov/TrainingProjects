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
        protected override string AddBody(IDictionary<string, string> form, string sessionId = null,IDictionary<string, string> errors = null)
        {
            Response response;
            StringBuilder body = new StringBuilder("<h1>ViewForm</h1>");
            try
            {
                //FormServiсe fs = new FormServiсe("forms.txt");
                SQLFormServise sfs = new SQLFormServise();
                Guid id = new Guid(form["id"]);

               // Form formclient = fs.GetElement(id);
                Form formclient = sfs.GetForm(id);
               // ClientServiсe cs = new ClientServiсe("client.txt");
                ClientServiсe cs = new ClientServiсe("Data Source=.\\SQLEXPRESS; Initial Catalog=WebServiceDB;Integrated Security=true;");
                Client c = cs.GetClientById(formclient.IdClient);

                body.Append(Environment.NewLine);
                //body.Append("<p><b id='col'>Name client:  </b>").Append(cs.GetElement(formclient.IdClient).Name + " " + cs.GetElement(formclient.IdClient).Surname).Append("</p>");
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
                body.Append("<th id='col'>Question</th>");
                body.Append(Environment.NewLine);
                body.Append("<th id='col'>Answer</th>");
                body.Append(Environment.NewLine);
                body.Append("</tr>");
                //var forms = fs.GetAll();
                var forms = sfs.GetAllModels("SELECT * FROM Forms");
                int n = 1;
                foreach (var element in forms)
                {
                    body.Append("<tr>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(n).Append("</td>");
                    body.Append(Environment.NewLine);
                   // body.Append("<td>").Append(element.Value.F1.ToString());
                    body.Append("<td>").Append(element.F1.ToString());
                    body.Append("<br>");
                   // body.Append(element.Value.F2.ToString());
                    body.Append("<td>").Append(element.F2.ToString());
                    body.Append("<br>");
                   // body.Append(element.Value.F3.ToString());
                    body.Append("<td>").Append(element.F3.ToString());
                    body.Append("<br>");
                    //body.Append(element.Value.F4.ToString());
                    body.Append("<td>").Append(element.F4.ToString());
                    body.Append("<br>");
                   // body.Append(element.Value.F5.ToString()).Append("</td>");
                    body.Append(element.F5.ToString()).Append("</td>");
                    body.Append("</td>").Append(Environment.NewLine);
                   // body.Append("<td>").Append(element.Value.Answer1);
                    body.Append("<td>").Append(element.Answer1);
                    body.Append("<br>");
                   // body.Append(element.Value.Answer2);
                    body.Append(element.Answer2);
                    body.Append("<br>");
                   // body.Append(element.Value.Answer3);
                    body.Append(element.Answer3);
                    body.Append("<br>");
                    //body.Append(element.Value.Answer4);
                    body.Append(element.Answer4);
                    body.Append("<br>");
                    //body.Append(element.Value.Answer5).Append("</td>");
                    body.Append(element.Answer5).Append("</td>");
                    body.Append("</td>").Append(Environment.NewLine);
                    body.Append("</tr>");
                    n++;
                }

                body.Append("</table>");
                body.Append("<br>");
                // ManagerService ms = new ManagerService("manager.txt");
                SQLManagerServise sms = new SQLManagerServise();
                Manager man = sms.GetManager(formclient.IdManager);
                body.Append(Environment.NewLine);
                // body.Append("<p><b id='col'>Manager:  </b>").Append(ms.GetElement(formclient.IdManager).Name + " " + ms.GetElement(formclient.IdManager).Surname).Append("</p>");
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

