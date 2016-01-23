using System;
using System.Text;
using CollectionLibrary;

namespace Routing.Pages.Helpers
{
    public  class HtmlBaseTag
    {
        private string _tagName;
        private string _tagContent;
        protected MyHashTable<string, string> _attributes;

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

            tag.Append(Environment.NewLine);
            tag.Append("<").Append(TagName).Append(" ");
            tag.Append(GetAttribut());
            tag.Append(ProcessingError(errors));

            tag.Append(">");
            tag.Append(GetTagContent());
            tag.Append(GetTagEnd());

            tag.Append(Environment.NewLine);
            return tag.ToString();
        }

        protected virtual string GetTagEnd()
        {
            StringBuilder tag = new StringBuilder();
            tag.Append("</").Append(TagName).Append(">");
            return tag.ToString();
        }

        protected virtual string GetTagContent()
        {
            return _tagContent;
        }

        protected virtual string ProcessingError(MyHashTable<string, string> errors)

        {
            return "";
        }
        

    }
}
