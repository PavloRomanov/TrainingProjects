using CollectionLibrary;
using System;
using System.Text;


namespace Routing.Pages.Helpers
{
    public class HtmlSelect : HtmlBaseTag
    {
        private string _name;
        private MyList<string> _options;
     
        public HtmlSelect( string name, MyList<string> options)
           : base("select")
        {
            _name = name;// name select
            _options = options;
            _attributes.Add(_name, "");
          
        }

     
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
