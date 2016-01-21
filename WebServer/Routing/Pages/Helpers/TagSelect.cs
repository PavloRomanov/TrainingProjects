using CollectionLibrary;
using System;
using System.Text;


namespace Routing.Pages.Helpers
{
    public class TagSelect : HtmlTag
    {
        private const string getName = "select";
        private string _name;
        private string _value;
        private MyList<string> _options;
        public TagSelect( string text)
            : base(getName, text)
        {
    
        }
        public TagSelect(string text, string name, string value)
           : base(getName, text)
        {
            _name = name;// name select
            _value = value;
            _options = new MyList<string>();
            SetAdditionalOptions("1 years");
            SetAdditionalOptions("3 years");
            SetAdditionalOptions("5 years");
        }
       
        public TagSelect SetAdditionalOptions(string _value)
        {
            _options.Add(_value);
            return this ;
        }
        public string GetTag()
        {
            StringBuilder bodySelect = new StringBuilder();
            bodySelect.Append(Environment.NewLine);
            bodySelect.Append("<").Append(_name).Append("  name='").Append(_name).Append("'>");
         
            foreach (var option in _options)
            {
                bodySelect.Append("<option>");
                bodySelect.Append(option);
                bodySelect.Append(Environment.NewLine);
                bodySelect.Append("</option>");
            }
            bodySelect.Append("</").Append(_name).Append(">");
            bodySelect.Append(Environment.NewLine);
            return bodySelect.ToString();
        }
    }
}
