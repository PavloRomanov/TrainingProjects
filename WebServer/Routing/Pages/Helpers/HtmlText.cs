using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;

namespace Routing.Pages.Helpers
{
    public class HtmlText : IHtmlElement
    {
        private string _text;

        public HtmlText(string text)
        {
            _text = text;
        }

        public string GetTag(MyHashTable<string, string> errors = null)
        {
            return _text;
        }
    }
}
