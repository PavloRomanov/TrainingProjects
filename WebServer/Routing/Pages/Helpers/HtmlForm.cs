using CollectionLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Routing.Pages.Helpers
{
    public class HtmlForm : HtmlBaseTag
    {
        //public readonly RequestMethod _method;
        //public readonly string _action;
        //public readonly List<HtmlBaseTag> _tags;
        public readonly MyHashTable<string, string> _errors;

        public HtmlForm(RequestMethod method, string action, MyHashTable<string, string> errors = null)
            : base("form")
        {
            SetAttribut("method", method.ToString());
            SetAttribut("action", action);
            //_method = method;
            //_action = action;
            _errors = errors;
            // _tags = new List<HtmlBaseTag>();

            AddHtmlElement(new HtmlInput(InputType.Reset.ToString(), "", "clear"));
            AddHtmlElement(new HtmlInput(InputType.Submit.ToString(), "", "submit"));
            AddHtmlElement(new HtmlBaseTag("br"));
        }


        public HtmlBaseTag AddTag(string name, string value = null)
        {

            HtmlBaseTag tag = new HtmlBaseTag(name, value);
            AddHtmlElement(tag);
            return tag;
        }

        public HtmlInput AddInput(string name, string value, InputType type, string text = null)
        {
            HtmlLable lable = new HtmlLable(text);
            AddHtmlElement(lable);
            HtmlInput input = new HtmlInput(type.ToString(), name, value);
            AddHtmlElement(input);

            return input;
        }

        public HtmlSelect AddSelect(string name, MyHashTable<string, string> options)
        {
            HtmlSelect select = new HtmlSelect(name, options);

            AddHtmlElement(select);

            return select;
        }

        public override string ToString()
        {
            return GetTag();
        }

        /*
        public override string ToString()
        {
            StringBuilder begin = new StringBuilder(Environment.NewLine);
            begin.Append("<form method='").Append(_method.ToString()).Append("' ");
            begin.Append("action ='").Append(_action).Append("'>");
            begin.Append(Environment.NewLine);

            foreach (var tag in _tags)
            {
                begin.Append(tag.GetTag(_errors));
                begin.Append("</br>");
                begin.Append(Environment.NewLine);
            }

            begin.Append("</br>");
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
        */
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
