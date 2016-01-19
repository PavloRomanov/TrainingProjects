using CollectionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing.Pages.Helpers
{
    public class TagSelect : HtmlTag
    {
        private string _name;
        private string _value;
        private MyList<string> _options;
        public TagSelect(string getName, string text)
            : base(getName, text)
        {
    
        }
        public TagSelect(string getName, string text, string name, string value)
           : base(getName, text)
        {
            _name = name;// name select
            _value = value;
            _options = new MyList<string>();    
        }
       
        public TagSelect SetAdditionalOptions(string _value)
        {
            _options.Add(_value);
            return this ;
        }
        public override string GetTag()
        {
            StringBuilder bodySelect = new StringBuilder();
            bodySelect.Append(Environment.NewLine);
            bodySelect.Append("<").Append(Name).Append(" ").Append("name='").Append(_name).Append("'>");
            bodySelect.Append("<option>");
            SetAdditionalOptions("1 years");
            SetAdditionalOptions("3 years");
            SetAdditionalOptions("5 years");
            foreach (var option in _options)
            {
                bodySelect.Append(option);
                bodySelect.Append(Environment.NewLine);
            }
            bodySelect.Append("</option>").Append("</").Append(Name).Append(">");
            bodySelect.Append(Environment.NewLine);
            return bodySelect.ToString();
        }
    }
}
