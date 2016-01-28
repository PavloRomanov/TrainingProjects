using System;
using CollectionLibrary;

namespace Routing.Pages
{
    public interface IBasePage
    {
        Response Get(MyHashTable<string, string> form, string sessionId = null, MyHashTable<string, string> errors = null);
        Response Post(MyHashTable<string, string> form, string sessionId = null);
    }
}
