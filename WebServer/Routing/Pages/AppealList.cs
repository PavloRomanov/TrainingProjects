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
    public class AppealList : BasePage
    {
        protected override string Title { get { return "Appeal's List"; } }

        protected override string AddBody(MyHashTable<string, string> form, string sessionId = null, MyHashTable<string, string> errors = null)
        {
            StringBuilder body = new StringBuilder();
            try
            {

                AppealServiсe aps = new AppealServiсe("appealclient.txt");
                HashDictionary<Guid, Appeal> appealclients = aps.GetAll();

                body.Append("<body bgcolor='#FFFF40\'>");
                body.Append(Environment.NewLine);
                body.Append("<h1>List Appeals</h1>");
                body.Append(Environment.NewLine);
                body.Append(Environment.NewLine);
                body.Append("<table width='100%' border='1' cellspacing='0' cellpadding='4'>");
                body.Append(Environment.NewLine);
                body.Append("<tr>");
                body.Append(Environment.NewLine);
                body.Append("<th>Number</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Name client</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Appeal of client</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Rezult</th>");
                body.Append(Environment.NewLine);
                body.Append("<th>Controls</th>");
                body.Append(Environment.NewLine);
                body.Append("</tr>");


                ClientServiсe cs = new ClientServiсe("client.txt");      
                int n = 1;
                foreach (var element in appealclients)
                {
                    body.Append("<tr>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(n).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(cs.GetElement(element.Value.IdClient).Name +" "+ cs.GetElement(element.Value.IdClient).Surname).Append("</td>");//???????
                    body.Append(Environment.NewLine);             
                    body.Append("<td>").Append(element.Value.ClientAppeal.ToString()).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td>").Append(element.Value.Rez).Append("</td>");
                    body.Append(Environment.NewLine);
                    body.Append("<td><a href='DeleteAppeal?id=").Append(element.Key).Append("'>Delete</a></td>");
                    body.Append(Environment.NewLine);
                    body.Append("<tr>");
                    n++;
                }

                body.Append("</table>");
                body.Append("<br>");
                body.Append(Environment.NewLine);
                body.Append("<a href='CreateAppeal'> Create new appeal </a>");
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
