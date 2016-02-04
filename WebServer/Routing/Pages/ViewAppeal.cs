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
  
        protected override string AddBody(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            Response response;
            StringBuilder body = new StringBuilder("<body bgcolor='#ff8c34'>");
            try
            {
                AppealServiсe aps = new AppealServiсe("appealclient.txt");
                Guid id = new Guid(form["id"]);

                Appeal appealclient = aps.GetElement(id);

                body.Append(Environment.NewLine);
                body.Append("<p><b>Name client:</b>").Append(appealclient.IdClient).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Content appeal:</b>").Append(appealclient.ClientAppeal).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Resalt:</b>").Append(appealclient.Rez).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>Comment:</b>").Append(appealclient.Comment).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<p><b>References:</b>").Append(appealclient.References).Append("</p>");
                body.Append(Environment.NewLine);
                body.Append("<a href='UpdateClient?id=").Append(id).Append("'>Update Client</a>");

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
