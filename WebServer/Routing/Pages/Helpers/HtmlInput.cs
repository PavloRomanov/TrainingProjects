using System;
using System.Text;
using CollectionLibrary;

namespace Routing.Pages.Helpers
{
    public abstract class HtmlInput : IHtmlControl
    {
        private string _name;
        private string _value;
        private MyHashTable<string, string> _additionalAttributes;

        public HtmlInput(string name)
            : this(name, null)
        {
        }

        public HtmlInput(string name, string value2 = null)
        {
            _name = name;
            _value = value2;
            _additionalAttributes = new MyHashTable<string, string>();

        }

        protected abstract string Type { get; }

        protected string Name { get { return _name; } }

        protected string Value { get { return _value; } }

        public HtmlInput SetAdditionalAttributes(string name, string value)
        {
            _additionalAttributes.Add(name, value);
            return this;
        }

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

            tag.Append(GetAdditionalAttributes());

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

        protected string GetAdditionalAttributes()
        {
            if(_additionalAttributes != null)
            {
                StringBuilder attributes = new StringBuilder();

                foreach(var atr in _additionalAttributes)
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
    }

}

