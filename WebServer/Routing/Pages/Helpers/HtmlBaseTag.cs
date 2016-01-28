using System;
using System.Text;
using CollectionLibrary;
using System.Collections.Generic;

namespace Routing.Pages.Helpers
{
    public  class HtmlBaseTag : IHtmlElement
    {
        private string _tagName;
        private List<IHtmlElement> _tagContent;
        private MyHashTable<string, string> _attributes;

        public HtmlBaseTag(string tagName)
            : this(tagName, null)
        {

        }

        public HtmlBaseTag(string tagName, string tagContent = null)
        {
            _tagName = tagName;
            _tagContent = new List<IHtmlElement>();
            _attributes = new MyHashTable<string, string>();

        }

        public MyHashTable<string, string> Attributes
        {
            get { return _attributes; }           
        }

        public List<IHtmlElement> TagContent
        {
            get { return _tagContent; }
        }

        protected string TagName { get { return _tagName; } }

        public virtual HtmlBaseTag SetTagContent(string tagName, string text = null)
        {
            if(tagName != "text")
            {
                HtmlBaseTag tag = new HtmlBaseTag(tagName);
                if(text != null)
                {
                    tag.SetTagContent("text", text);
                }
                _tagContent.Add(tag);
            }
            else
            {
                HtmlText tag = new HtmlText(text);
                _tagContent.Add(tag);
            }            

            return this;
        }

       /* public virtual HtmlBaseTag SetTagContent(IHtmlElement tag)
        {            
            _tagContent.Add(tag);
            
            return this;
        }*/

        protected string GetTagContent()
        {
            if(_tagContent != null)
            {
                StringBuilder content = new StringBuilder();

                foreach (var element in _tagContent)
                {
                    content.Append(element.GetTag()).Append(Environment.NewLine);
                }
                return content.ToString();
            }
            return "";
        }
        
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
        
        protected virtual string ProcessingError(MyHashTable<string, string> errors)
        {
            return "";
        }
        

    }
}
