using System;
using System.Collections.Generic;
using Model.Servise;

namespace Routing.Pages
{
    public class DeleteClient : IBasePage
    {
        AbstractServiceFactory serviceFactory;
        public DeleteClient(AbstractServiceFactory sf)         
        {
            serviceFactory = sf;
        }

        public Response Get(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            Response response;
            try
            {
                IClientService cs = serviceFactory.CreateClientServise();
                Guid id = new Guid(form["id"]);
                //cs.Delete(id);
                cs.Delete(id);
            }
           catch(Exception)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                return response;
            }

            return new Response("", TypeOfAnswer.Redirection, "ClientsList");            
        }

       
        public Response Post(IDictionary<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }
    }
}
