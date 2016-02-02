using System;
using System.Collections.Generic;
using CollectionLibrary;

namespace Routing.Pages
{
    public interface IBasePage
    {
        Response Get(MyHashTable<string, string> form, string sessionId = null, IDictionary<string, string> errors = null);
        Response Post(MyHashTable<string, string> form, string sessionId = null);
    }
}
