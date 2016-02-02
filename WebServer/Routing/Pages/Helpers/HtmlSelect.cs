using CollectionLibrary;
using System;
using System.Text;
using System.Collections.Generic;



namespace Routing.Pages.Helpers
{
    public class HtmlSelect : HtmlBaseTag
    {
        private string _name;
        private IDictionary<string, string> _options;
     
        public HtmlSelect( string name, IDictionary<string, string> options)
           : base("select")
        {
            _name = name;// name select
            _options = options;
            SetAttribut("name",_name);
          
        }
        public override string GetTagContent()
        {
            StringBuilder bodyoption = new StringBuilder();
            bodyoption.Append(Environment.NewLine);
            foreach (var opin in _options)
            {
                bodyoption.Append("<").Append("option  ");
                bodyoption.Append("value= ").Append(opin.Key);
                bodyoption.Append(">");
                bodyoption.Append(opin.Value);
                bodyoption.Append("</").Append("option").Append(">");
                bodyoption.Append(Environment.NewLine);
            }
            bodyoption.Append(Environment.NewLine);
            return bodyoption.ToString();
        }

        /*
        public HtmlSelect(string name, MyHashTable<string, string> options)
           : base("select")
        {
            _name = name;// name select
            //_options = options;
            SetAttribut("name", _name);

            foreach (var opin in options)
            {
                var o = new HtmlBaseTag("option");
                o.SetAttribut("value", opin.Key);
                o.AddHtmlElement(new HtmlText(opin.Value));
                AddHtmlElement(o);
            }

        }
        */

        /*  public override string GetTag()
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
          }*/
    }
}
