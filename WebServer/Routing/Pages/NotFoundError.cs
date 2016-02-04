using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;

namespace Routing.Pages
{
    public class NotFoundError : IBasePage
    {
        public Response Get(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            return new Response("", TypeOfAnswer.ClientError, "");
        }

        public Response Post(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }
    }
}
