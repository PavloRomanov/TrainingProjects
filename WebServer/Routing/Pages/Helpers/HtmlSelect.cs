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
            Attributes.Add(_name, "");
          
        }

       
        public override HtmlBaseTag SetTagContent(string value, string text)
        {
            HtmlBaseTag tag = new HtmlBaseTag("option");
            tag.SetTagContent("text", text);
            tag.SetAttribut("value", value);
            return this;
        }
        /*protected override string GetTagContent()
        {
            StringBuilder bodyoption = new StringBuilder();
            bodyoption.Append(Environment.NewLine);
            foreach (var opin in _options)
            {
                bodyoption.Append("<").Append("option").Append(">");
                bodyoption.Append(opin);
                bodyoption.Append(Environment.NewLine);
                bodyoption.Append("</").Append("option").Append(">");
             
            }
            bodyoption.Append(Environment.NewLine);
            return bodyoption.ToString();
        }*/

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

        private class HtmlOption : HtmlBaseTag
        {
            public HtmlOption(string value, string text)
                :base("option")
            {
                Attributes.Add("value", value);
                TagContent.Add(new HtmlText(text));
            }
        }
    }
}
