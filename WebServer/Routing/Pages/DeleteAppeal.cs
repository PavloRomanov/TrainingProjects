using System;
using System.Collections.Generic;
//using CollectionLibrary;
using Model.Servise;

namespace Routing.Pages
{
    public class DeleteAppeal : IBasePage
    {
        AbstractServiceFactory serviceFactory;
        public DeleteAppeal(AbstractServiceFactory sf)
        {
            serviceFactory = sf;
        }

        public Response Get(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null)
        {

        Response response;
            try
            {
                //AppealServiсe cs = new AppealServiсe("appealclient.txt");
                IAppealService aps = serviceFactory.CreateAppealService();
          
                Guid id = new Guid(form["id"]);
                aps.Delete(id);
            }
            catch (Exception)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                return response;
            }

            return new Response("", TypeOfAnswer.Redirection, "AppealList");

        }
        public Response Post(IDictionary<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }

    }
}