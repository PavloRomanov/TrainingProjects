using System;
using System.Text;
using CollectionLibrary;

namespace Routing.Pages.Helpers
{
    public abstract class HtmlBaseTag
    {
        private string _tagName;
        private string _tagContent;
        private MyHashTable<string, string> _attributes;

        public HtmlBaseTag(string name)
        {

        }

        public HtmlBaseTag(string name, string content = null)
        {
            _tagName = name;
            _tagContent = content;
            _attributes = new MyHashTable<string, string>();

        }

    }
}
