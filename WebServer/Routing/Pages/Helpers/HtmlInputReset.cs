﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing.Pages.Helpers
{
    class HtmlInputReset :HtmlInput
    {
        private string _name;
        private string _value;
       
        public HtmlInputReset(string name)
            : base(name, null)
        {
        }

        public HtmlInputReset(string name, string value)
            : base(name, value)
        {
            _name = name;
            _value = value;
        }
      
        protected override string Type { get { return "reset"; } }

    }
}
