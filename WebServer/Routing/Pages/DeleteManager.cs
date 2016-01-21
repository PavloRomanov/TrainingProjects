using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;
using Model.Servise;

namespace Routing.Pages
{
    public class DeleteManager: IBasePage
    {
        public Response Get(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {
            Response response;
            try
            {
                ManagerService ms = new ManagerService("manager.txt");
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


        public Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {
            throw new NotImplementedException();
        }
    }
}

