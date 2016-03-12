using System;
using Model.Servise;
using System.Collections.Generic;

namespace Routing.Pages
{
    public class DeleteManager: IBasePage
    {
        AbstractServiceFactory serviceFactory;
        public DeleteManager(AbstractServiceFactory sf) 
        {
            serviceFactory = sf;
        }

        public Response Get(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {
            Response response;
            try
            {
                IManagerService ms = serviceFactory.CreateManagerService();
                Guid id = new Guid(form["id"]);
                ms.Delete(id);
            }
            catch (Exception)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                return response;
            }

            return new Response("", TypeOfAnswer.Redirection, "ManagersList");
        }


        public Response Post(IDictionary<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }
    }
}

