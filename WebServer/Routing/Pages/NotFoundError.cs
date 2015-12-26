using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;

namespace Routing.Pages
{
    public class NotFoundError : IBasePage
    {
        public Response Get(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {
            return new Response("", TypeOfAnswer.ClientError, "");
        }

        public Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {
            throw new NotImplementedException();
        }
    }
}
