using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;
using Model.Servise;

namespace Routing.Pages
{
    public class DeleteClient : IBasePage
    {
        public Response Get(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            Response response;
            try
            {
                ClientServiсe cs = new ClientServiсe("client.txt");
                Guid id = new Guid(form["id"]);
                cs.Delete(id);               
            }
           catch(Exception)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                return response;
            }

            return new Response("", TypeOfAnswer.Redirection, "ClientsList");            
        }

       
        public Response Post(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }
    }
}
