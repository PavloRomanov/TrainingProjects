using System;
using CollectionLibrary;

namespace Routing.Pages
{
    class FormPage : BasePage
    {
        public FormPage()
            : base()
        {

        }

        public override Response Post(MyHashTable<string, string> form, MyHashTable<string, string> cookies)
        {
            throw new NotImplementedException();
        }
      
        protected override string AddBody(MyHashTable<string, string> form, MyHashTable<string, string> cookies, MyHashTable<string, string> errors)
        {
            throw new NotImplementedException();
        }

  
    }
}
