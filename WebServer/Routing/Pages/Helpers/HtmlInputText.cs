using System;


namespace Routing.Pages.Helpers
{
    public class HtmlInputText : HtmlInput
    {
        private string _name;
        private string _value;

        public HtmlInputText(string name)
            : base(name, null)
        {
        }

        public HtmlInputText(string name, string value)
            : base(name, value)
        {
            _name = name;
            _value = value;
        }

        protected override string Type { get { return "text"; } }       
        
    }
}