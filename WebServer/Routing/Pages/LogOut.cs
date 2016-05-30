using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;
using Model.Servise;

namespace Routing.Pages
{
    public class LogOut : IBasePage
    {
       /* public LogOut(AbstractServiceFactory sf)
            :base(sf)
        {
        }*/

        public Response Get(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            if (sessionId != null )
            {
                Session.Instance[sessionId].Authorized = false;              
            }

            return new Response("", TypeOfAnswer.Redirection, "Index");
        }

        public Response Post(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }
    }
}
