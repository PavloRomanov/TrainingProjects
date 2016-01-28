using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;

namespace Routing.Pages.Helpers
{
    public class HtmlBr : IHtmlElement
    {
        public string GetTag(MyHashTable<string, string> errors = null)
        {
            return "</br>";
        }
    }
}
