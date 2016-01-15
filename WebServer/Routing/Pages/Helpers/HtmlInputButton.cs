using System;


namespace Routing.Pages.Helpers
{
    class HtmlInputButton : HtmlInput
    {
        private string _name;
        private string _value;

        public HtmlInputButton(string name)
            : base(name, null)
        {
        }

        public HtmlInputButton(string name, string value)
             : base(name, value)
        {
            _name = name;
            _value = value;
        }
        
        protected override string Type { get { return "submit"; } }

    }
}
