using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollectionLibrary;

namespace Routing.Pages.Helpers
{
    public interface IHtmlControl
    {
        string GetTag(MyHashTable<string, string> errors = null, string atr1 = null);       
    }
}
