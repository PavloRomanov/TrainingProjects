using System;
using CollectionLibrary;
using Model.Servise;
using System.Collections.Generic;


namespace Routing.Pages
{
    public class DeleteForm : IBasePage
    {
        public Response Get(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null, System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            Response response;
            try
            {
                FormServiсe cs = new FormServiсe("forms.txt");
                Guid id = new Guid(form["id"]);
                cs.Delete(id);
            }
            catch (Exception)
            {
                response = new Response("", TypeOfAnswer.ServerError, "");
                return response;
            }

            return new Response("", TypeOfAnswer.Redirection, "FormList");
        }

        public Response Post(System.Collections.Generic.IDictionary<string, string> form, string sessionId = null)
        {
            throw new NotImplementedException();
        }
    }
}
