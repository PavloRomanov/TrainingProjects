using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;

namespace Routing.Pages
{
    public class LogOut : IBasePage
    {
        public Response Get(MyHashTable<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            if (sessionId != null )
            {
                Session.Instance[sessionId].Authorized = false;              
            }

            return new Response("", TypeOfAnswer.Redirection, "Index");
        }

        public Response Post(MyHashTable<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }
    }
}
