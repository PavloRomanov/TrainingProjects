using System;
using System.Text;
using CollectionLibrary;

namespace Routing.Pages.Helpers
{
    public class HtmlInputText : HtmlInput
    {
        private string _name;
        private string _value;

        public HtmlInputText(string name)
            : this(name, null)
        {
        }

        public HtmlInputText(string name, string value)
        {
            _name = name;
            _value = value;
        }

        protected override string Type { get { return "text"; } }

        protected override string Name { get { return _name; } }

        protected override string Value { get { return _value; } }

        protected override string AdditionalAttributes(string atr1, string atr2 = null)
        {
            return "";
        }
    }
}