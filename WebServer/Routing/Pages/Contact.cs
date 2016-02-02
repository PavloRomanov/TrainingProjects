using Routing.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;

namespace Routing.Pages
{
    public class Contact : BasePage
    {
        protected override string AddBody(MyHashTable<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            Response response;
            StringBuilder body = new StringBuilder();
            try
            {
                body.Append(Environment.NewLine).Append("<div class='connect'>");
                body.Append("<h1>Call if you have questions!</h1>");
                body.Append(Environment.NewLine);
                body.Append("<pre>").Append(" moby phone: +3 8(067) 345 65 76");
                body.Append(Environment.NewLine);
                body.Append(" city phone:   (044) 345 67 89").Append("</pre>");
                body.Append(Environment.NewLine);
                body.Append("</div>");
                body.Append("<img src='telephone.jpg' style='width:900px;height:500px;border:0'>");
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