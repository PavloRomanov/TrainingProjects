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

        protected override string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {

            StringBuilder body = new StringBuilder();
            try
            {
                ManagerServise ms = new ManagerServise("manager.txt");
                HashDictionary<Guid, Manager> managers = ms.GetAll();

                body.Append("<body bgcolor='#FFFF40\'>");
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
                body.Append("<th>Work</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Address</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Phone</th>");
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
                    body.Append("<td>").Append(man.Value.Name).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(man.Value.Surname).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(man.Value.Work.ToString()).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(man.Value.Address).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(man.Value.Phone).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>");
                    body.Append("<a href='ViewManager?id=").Append(man.Key).Append("'>View</a>");
                    body.Append("<a href='UpdateManager?id=").Append(man.Key).Append("'>Update</a>");
                    body.Append("<a href='DeleteManager?id=").Append(man.Key).Append("'>Delete</a>");
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

        public override Response Post(MyHashTable<string, string> form,MyHashTable<string, string> cookies)
        {
            throw new NotImplementedException();
        }
    }



}

