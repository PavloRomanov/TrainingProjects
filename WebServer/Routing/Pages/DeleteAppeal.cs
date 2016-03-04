using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CollectionLibrary;
using Model.Servise;
using Routing.Pages;

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
                SQLAppealService cs = new SQLAppealService("Appeals");
                Guid id = new Guid(form["id"]);
                cs.Delete(id);
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