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
   public class ViewAppeal : BasePage
    {
  
        protected override string AddBody(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            Response response;
            StringBuilder body = new StringBuilder("<h1>ViewAppeal</h1>");

            try
            {
                AppealServiсe aps = new AppealServiсe("appealclient.txt");
                Guid id = new Guid(form["id"]);
                ClientServiсe cs = new ClientServiсe("client.txt");
                Appeal appealclient = aps.GetElement(id);

                body.Append(Environment.NewLine);
                body.Append("<p><b>Name client:   </b>").Append(cs.GetElement(appealclient.IdClient).Name + " " + cs.GetElement(appealclient.IdClient).Surname).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Content appeal:   </b>").Append(appealclient.ClientAppeal).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Problem solved?:   </b>").Append(appealclient.Rez).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Comment:   </b>").Append(appealclient.Comment).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>References:   </b>").Append(appealclient.References).Append("</p>");
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
