using System;
using System.Text;

using System.Collections.Generic;

namespace Routing.Pages.Helpers
{
    public  class HtmlBaseTag : IHtmlElement
    {
        private string _tagName;
        private string _text = "";
        private string _message = "";
        private Dictionary<string, string> _attributes;
        private List<HtmlBaseTag> _tagContent;

        public HtmlBaseTag(string tagName, string text = null)
        {
            _tagName = tagName;
            if (text != null) _text = text;
            _attributes = new Dictionary<string, string>();
            _tagContent = new List<HtmlBaseTag>();
        }      

        protected string TagName { get { return _tagName; } }
        protected List<HtmlBaseTag> TagContent { get { return _tagContent; } }


        public virtual HtmlBaseTag AddTag(HtmlBaseTag inerTag)
        {
            _tagContent.Add(inerTag);
            return inerTag;
        }

        public virtual HtmlBaseTag AddTag(string name, string text = null)
        {
            HtmlBaseTag inerTag = new HtmlBaseTag(name, text);            
            _tagContent.Add(inerTag);

            return inerTag; 
        }

        public virtual string GetTagContent()
        { 
            if(_tagContent != null)
            {
                StringBuilder content = new StringBuilder(Environment.NewLine);
                foreach(var c in _tagContent)
                {
                    content.Append(c.GetTag()).Append(Environment.NewLine);
                }
                return content.ToString();
            }
            else
        { 
                return "";
            }            
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

        public string GetTag(System.Collections.Generic.IDictionary<string, string> errors = null)
        {
            StringBuilder tag = new StringBuilder(Environment.NewLine);           

            tag.Append(Environment.NewLine);
            tag.Append("<").Append(TagName).Append(" ");

            //tag.Append(ProcessingError(errors));

            tag.Append(GetAttribut());

            tag.Append(">");
            tag.Append(_text);
            tag.Append(GetTagContent());
            tag.Append(GetTagEnd());

            //tag.Append("<span style = 'color:red'>").Append(_message).Append("</span>");

            tag.Append(Environment.NewLine);
            return tag.ToString();
        }

        protected virtual string GetTagEnd()
        {
            StringBuilder tag = new StringBuilder();
            tag.Append("</").Append(TagName).Append(">");
            return tag.ToString();
        }
        
        protected virtual string ProcessingError(System.Collections.Generic.IDictionary<string, string> errors)
        {
            if(errors != null && errors.ContainsKey(_tagName))
        {
                SetAttribut("style", "border-color:red");
                _message = errors[_tagName];
            }
            return "";
        }
        protected virtual string AddScript()
        {
            return "";
        }

    }
}
