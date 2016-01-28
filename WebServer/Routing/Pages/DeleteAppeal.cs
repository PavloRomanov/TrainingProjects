using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;
using Model.Servise;
using Routing.Pages;

namespace Routing.Pages
{
    public class DeleteAppeal : IBasePage
    {
       

        public Response Get(MyHashTable<string, string> form,MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {

        Response response;
            try
            {
                AppealServiсe cs = new AppealServiсe("appealclient.txt");
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
        public Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {
            throw new NotImplementedException();
        }

    }
}