using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;

namespace Routing.Pages
{
    public class LogOut : IBasePage
    {
        public Response Get(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors = null)
        {
            if (cookies != null && cookies.ContainsKey(" sessionId"))
            {
                string key = cookies[" sessionId"];
                Session.Instance.Remove(key);                
            }

            return new Response("", TypeOfAnswer.Redirection, "Index");
        }

        public Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {
            throw new NotImplementedException();
        }
    }
}
