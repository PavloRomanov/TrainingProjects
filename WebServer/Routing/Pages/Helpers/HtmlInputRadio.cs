using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing.Pages.Helpers
{
    public class HtmlInputRadio : HtmlInput
    {
        private string _name;
        private string _value;

        public HtmlInputRadio(string name)
            : base(name, null)
        {
        }

        public HtmlInputRadio(string name, string value)
            : base(name, value)
        {
            _name = name;
            _value = value;
        }

        protected override string Type { get { return "radio"; } }
    }
}
