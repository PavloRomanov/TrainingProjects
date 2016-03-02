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
    public class ManagersList : BasePage
    {
        protected override string Title { get { return "Manager's List"; } }

        protected override string AddBody(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {

            StringBuilder body = new StringBuilder();
            try
            {
                //ManagerService ms = new ManagerService("manager.txt");
                SQLManagerServise sms = new SQLManagerServise("Managers");
                //Dictionary<Guid, Manager> managers = ms.GetAll();
                List<Manager> managers = sms.GetAllManagers();
                body.Append(Environment.NewLine);
                body.Append("<h1>List Managers</h1>");
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
                body.Append("<th>Experience of Work</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Address</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Phone</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Login</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Password</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>controls</th>");
                body.Append(Environment.NewLine);
                body.Append("</tr>");


                int n = 1;
                foreach (var man in managers)
                {
                    body.Append("<tr>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(n).Append("</td>");
                    body.Append(Environment.NewLine);
                   // body.Append("<td>").Append(man.Value.Name).Append("</td>");
                    body.Append("<td>").Append(man.Name).Append("</td>");
                    body.Append(Environment.NewLine);
                    //body.Append("<td>").Append(man.Value.Surname).Append("</td>");
                    body.Append("<td>").Append(man.Surname).Append("</td>");
                    body.Append(Environment.NewLine);
                   // body.Append("<td>").Append(man.Value.Work.ToString()).Append("</td>");
                    body.Append("<td>").Append(man.Work.ToString()).Append("</td>");
                    body.Append(Environment.NewLine);
                   // body.Append("<td>").Append(man.Value.Address).Append("</td>");
                    body.Append("<td>").Append(man.Address).Append("</td>");
                    body.Append(Environment.NewLine);
                   // body.Append("<td>").Append(man.Value.Phone).Append("</td>");
                    body.Append("<td>").Append(man.Phone).Append("</td>");
                    body.Append(Environment.NewLine);
                    // body.Append("<td>").Append(man.Value.Login).Append("</td>");
                    body.Append("<td>").Append(man.Login).Append("</td>");
                    body.Append(Environment.NewLine);
                    // body.Append("<td>").Append(man.Value.Password).Append("</td>");
                    body.Append("<td>").Append(man.Password).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>");
                   // body.Append("<a href='ViewManager?id=").Append(man.Key).Append("'>View</a>");
                   // body.Append("<a href='UpdateManager?id=").Append(man.Key).Append("'>Update</a>");
                  //  body.Append("<a href='DeleteManager?id=").Append(man.Key).Append("'>Delete</a>");
                    body.Append("<a href='ViewManager?id=").Append(man.Id).Append("'>View</a>");
                    body.Append("<a href='UpdateManager?id=").Append(man.Id).Append("'>Update</a>");
                    body.Append("<a href='DeleteManager?id=").Append(man.Id).Append("'>Delete</a>");
                    body.Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<tr>");
                    n++;
                }

                body.Append("</table>");
                body.Append(Environment.NewLine);
                body.Append(Environment.NewLine);
                body.Append("<a href='CreateManager'>   Create new manager </a>");
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

