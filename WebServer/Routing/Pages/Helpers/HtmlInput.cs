using System;
using System.Text;
using CollectionLibrary;

namespace Routing.Pages.Helpers
{
    public class HtmlInput : HtmlBaseTag
    {
       
        public HtmlInput(string type, string name, string value)
        : base("input")
        {
            Attributes.Add("type", type);
            Attributes.Add("name", name);
            Attributes.Add("value", value);            
        }
               

        protected override string GetTagEnd()
        {
            return "";
        }

        protected override string GetTagContent()
        {
            return  "";
        }

        protected override string ProcessingError(MyHashTable<string, string> errors)
        {
            StringBuilder tag = new StringBuilder(Environment.NewLine);
            if (errors != null)
            {
                if (errors.ContainsKey(TagName))
                {
                    tag.Append("style='border-color:red'/>");
                    string message = errors[TagName];
                    tag.Append("<span style = 'color:red'>").Append(message).Append("</span>");

                }
                return tag.ToString();
            }
                return "";
        }


    }

}

