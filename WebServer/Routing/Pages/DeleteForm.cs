using System;
using Model.Servise;
using System.Collections.Generic;


namespace Routing.Pages
{
    public class DeleteForm : IBasePage
    {
        AbstractServiceFactory serviceFactory;
        public DeleteForm(AbstractServiceFactory sf)
        {
            serviceFactory = sf;
        }

        public Response Get(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            Response response;
            try
            {
                //FormServiсe fs = new FormServiсe("forms.txt");
                IFormService fs = serviceFactory.CreateFormServise();
                Guid id = new Guid(form["id"]);
                fs.Delete(id);
            }
            catch (Exception)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                return response;
            }

            return new Response("", TypeOfAnswer.Redirection, "FormList");
        }

        public Response Post(IDictionary<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }
    }
}
