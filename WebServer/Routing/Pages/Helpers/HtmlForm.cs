using CollectionLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Routing.Pages.Helpers
{
    public class HtmlForm
    {
        public readonly RequestMethod _method;
        public readonly string _action;
        public readonly List<HtmlBaseTag> _tags;
        public readonly MyHashTable<string, string> _errors;

        public HtmlForm(RequestMethod method, string action, MyHashTable<string, string> errors = null)
        {
            _method = method;
            _action = action;
            _errors = errors;
            _tags = new List<HtmlBaseTag>();
        }

        
        public HtmlBaseTag AddTag(string name, string value = null)
        {
            HtmlBaseTag tag = new HtmlBaseTag(name, value);
            _tags.Add(tag);
            return tag;
        }
     
        public HtmlInput AddInput(string name, string value, InputType type)
        {
            HtmlInput input = new HtmlInput(type.ToString(), name, value);           

            _tags.Add(input);

            return input;
        }
        public HtmlSelect AddSelect(string name, MyHashTable<string,string> options)
        {
            HtmlSelect select = new HtmlSelect(name, options);

            _tags.Add(select);

            return select;
        }

        public override string ToString()
        {
            StringBuilder begin = new StringBuilder(Environment.NewLine);
            begin.Append("<form method='").Append(_method.ToString()).Append("' ");
            begin.Append("action ='").Append(_action).Append("'>");
            begin.Append(Environment.NewLine);
           
            foreach (var tag in _tags)
            {
                begin.Append(tag.GetTag(_errors));
                begin.Append(Environment.NewLine);//////////////////////////////////////////////////////////////////
            }
            
            begin.Append(Environment.NewLine);
            begin.Append(new HtmlInput(InputType.Reset.ToString(), "", "clear").GetTag());
            begin.Append(Environment.NewLine);
            begin.Append(Environment.NewLine);
            begin.Append(new HtmlInput(InputType.Submit.ToString(), "", "submit").GetTag());
            begin.Append(Environment.NewLine);
            begin.Append("</form>");
            begin.Append(Environment.NewLine);

            return begin.ToString();
        }
    }

    public enum RequestMethod
    {
        GET,
        POST
    }

    public enum InputType
    {
        Button,
        Checkbox,
        File,
        Hidden,
        Image,
        Password,
        Radio,
        Reset,
        Submit,
        Text
    }
}
