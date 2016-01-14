using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing.Pages.Helpers
{
    class HtmlInputButton : HtmlInput
    {
        private string _name;
        private string _value;

        public HtmlInputButton(string name)
            : this(name, null)
        {
        }

        public HtmlInputButton(string name, string value)
        {
            _name = name;
            _value = value;
        }

        /*public HtmlInputButton(string name)
            : base(name, null)
        {
        }

        public HtmlInputButton(string name, string value)
            : base(name, value)
        {
            _name = name;
            _value = value;
        }*/

        protected override string Type { get { return "submit"; } }

        protected override string Name { get { return _name; } }

        protected override string Value { get { return _value; } }


        protected override string AdditionalAttributes()
        {
            return "";
        }
    }
}
