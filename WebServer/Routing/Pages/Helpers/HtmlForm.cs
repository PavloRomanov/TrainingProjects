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
        public readonly List<HtmlInput> _inputs;
        public readonly List<HtmlTag> _tags;//-----------------
        public readonly MyHashTable<string, string> _errors;

        public HtmlForm(RequestMethod method, string action, MyHashTable<string, string> errors = null)
        {
            _method = method;
            _action = action;
            _errors = errors;
            _inputs = new List<HtmlInput>();
            _tags = new List<HtmlTag>();//--------------
        }

        //---------------------------------------------------------------------
        public HtmlTag AddTag(string name, string value)
        {
            HtmlTag tag = new HtmlTag(name, value);
            _tags.Add(tag);
            return tag;
        }
        //----------------------------------------------------------------------
        public HtmlInput AddInput(string name, string value, InputType type)
        {
            HtmlInput input;

            switch (type)
            {
                case InputType.text :
                    input = new HtmlInputText(name, value);
                    break;

                case InputType.button:
                    input = new HtmlInputButton(name, value);
                    break;

                case InputType.reset:
                    input = new HtmlInputReset(name, value);
                    break;
                case InputType.hidden:
                    input = new HtmlInputReset(name, value);
                    break;

                default:
                    input = new HtmlInputText(name, value); 
                    break;
            }

            _inputs.Add(input);

            return input;
        }        

        public override string ToString()
        {
            StringBuilder begin = new StringBuilder(Environment.NewLine);
            begin.Append("<form method='").Append(_method.ToString()).Append("' ");
            begin.Append("action ='").Append(_action).Append("'>");
            begin.Append(Environment.NewLine);


            foreach(var input in _inputs)
            {
                begin.Append(input.GetTag(_errors));
            }
            //=============================================
            foreach (var tag in _tags)
            {
                begin.Append(tag.GetTag(_errors));
            }
            //==============================================
            begin.Append(Environment.NewLine);
            begin.Append(new HtmlInputReset("", "clear").GetTag());
            begin.Append(new HtmlInputButton("", "submit").GetTag());
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
        button,
        checkbox,
        file,
        hidden,
        image,
        password,
        radio,
        reset,
        submit,
        text
    }
}
