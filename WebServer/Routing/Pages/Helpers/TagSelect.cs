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
        private const string getName = "select";
        private string _name;
        private MyList<string> _options;
        public TagSelect( string text)
            : base(getName, text)
        {
    
        }
      
        public TagSelect(string text, string name, MyList<string> options)
            : base(getName, text)
        {
            _name = name;// name select
            _options = options;
          
        }
       
        public override string GetTag()
        {
            StringBuilder bodySelect = new StringBuilder();
            bodySelect.Append(Environment.NewLine);
            bodySelect.Append("<").Append(Name).Append("  name='").Append(_name).Append("'>");
         
            foreach (var option in _options)
            {
                bodySelect.Append("<option>");
                bodySelect.Append(option);
                bodySelect.Append(Environment.NewLine);
                bodySelect.Append("</option>");
            }
            bodySelect.Append("</").Append(Name).Append(">");
            bodySelect.Append(Environment.NewLine);
            return bodySelect.ToString();
        }
    }
}
