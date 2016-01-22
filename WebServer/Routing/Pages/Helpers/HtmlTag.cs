using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionLibrary;
namespace Routing.Pages.Helpers
{
    public class HtmlTag
    {
        private string _tagName;
        private string _text;
        private MyHashTable<string, string> _additionalAttributes;
        public HtmlTag(string tagName, string text)
        {
            _tagName = tagName;           
            _text = text;
            _additionalAttributes = new MyHashTable<string, string>();
        }

      
        protected string Name { get { return _tagName; } }

        protected string Text { get { return _text; } }

         public HtmlTag SetAdditionalAttributes(string name, string value)
         {
             _additionalAttributes.Add(name, value);
             return this;
         }
         protected string GetAdditionalAttributes()
         {
             if (_additionalAttributes != null)
             {
                 StringBuilder attributes = new StringBuilder();

                 foreach (var atr in _additionalAttributes)
                 {
                     attributes.Append(atr.Key).Append("='").Append(atr.Value).Append("' ");
                 }
                 return attributes.ToString();
             }
             else
             {
                 return "";
             }
         }
         
        public virtual string GetTag()
        {

            StringBuilder bodyTag = new StringBuilder();
            bodyTag.Append(Environment.NewLine);
            bodyTag.Append("<").Append(Name).Append(">").Append(Text).Append("</").Append(Name).Append(">");
            bodyTag.Append(Environment.NewLine);
            bodyTag.Append(GetAdditionalAttributes());

            return bodyTag.ToString();

        }
        /*
            StringBuilder tag = new StringBuilder(Environment.NewLine);
            tag.Append("<br/>");
            tag.Append(Name + "<br/>");
            tag.Append(Environment.NewLine);
            //if (Name != null)
               // tag.Append("name='").Append(Name).Append("' ");
            if (Value != null)
                // tag.Append("value='").Append(Value).Append("' ");
                tag.Append(Value);

            tag.Append(GetAdditionalAttributes());

            //--------------------------------------------------------------------
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
        */

    }
}
