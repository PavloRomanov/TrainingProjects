using System;
using System.Text;
using CollectionLibrary;

namespace Routing.Pages.Helpers
{
    public abstract class HtmlInput : IHtmlControl
    {      
        protected abstract string Type { get; }

        protected virtual string Name { get { return string.Empty; } }

        protected virtual string Value { get { return string.Empty; } }

        public string GetTag(MyHashTable<string, string> errors = null)
        {
            StringBuilder tag = new StringBuilder(Environment.NewLine);
            tag.Append("<br/>");
            tag.Append(Name + "<br/>");
            tag.Append(Environment.NewLine);
            tag.Append("<input type='").Append(Type).Append("' ");
            if (Name != null)
                tag.Append("name='").Append(Name).Append("' ");
            if (Value != null)
                tag.Append("value='").Append(Value).Append("' ");

            tag.Append(AdditionalAttributes());

            if (errors != null)
            {
                if (errors.ContainsKey(Name))
                {
                    tag.Append("style='border-color:red'/>");
                    string message = errors[Name];
                    tag.Append("<span style = 'color:red'>").Append(message).Append("</span>");                   

                }
                else
                {
                    tag.Append("/>");
                    tag.Append(Environment.NewLine);
                    tag.Append("<br/>");
                }
            }
            else
            {
                tag.Append("/>");
                tag.Append(Environment.NewLine);
                tag.Append("<br/>");
            }


            tag.Append(Environment.NewLine);

            return tag.ToString();
        }

        protected abstract string AdditionalAttributes();
    }

}

