using System;
using System.Text;
using CollectionLibrary;

namespace Routing.Pages.Helpers
{
    public abstract class HtmlBaseTag
    {
        private string _tagName;
        private string _tagContent;
        private MyHashTable<string, string> _attributes;

        public HtmlBaseTag(string tagName)
            : this(tagName, null)
        {

        }

        public HtmlBaseTag(string tagName, string tagContent = null)
        {
            _tagName = tagName;
            _tagContent = tagContent;
            _attributes = new MyHashTable<string, string>();

        }
        
        protected abstract string GetLable { get; }

        protected string TagName { get { return _tagName; } }

        protected string TagContent { get { return _tagContent; } }

        public HtmlBaseTag SetAttribut(string attributName, string attributValue)
        {
            _attributes.Add(attributName, attributValue);
            return this;
        }

        protected string GetAttribut()
        {
            if (_attributes != null)
            {
                StringBuilder attributes = new StringBuilder();

                foreach (var atr in _attributes)
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

        public string GetTag(MyHashTable<string, string> errors = null)
        {
            StringBuilder tag = new StringBuilder(Environment.NewLine);
            tag.Append(GetLable);            
            tag.Append(Environment.NewLine);
            tag.Append("<").Append(TagName).Append(">");
            tag.Append(TagContent);
            tag.Append("</").Append(TagName).Append(">");

            tag.Append(GetAttribut());

           /* if (errors != null)
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
            }*/


            tag.Append(Environment.NewLine);

            return tag.ToString();
        }

    }
}
