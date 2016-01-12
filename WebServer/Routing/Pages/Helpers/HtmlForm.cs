using CollectionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing.Pages.Helpers
{
    public class HtmlForm
    {
        public readonly RequestMethod _method;
        public readonly string _action;
        public readonly List<HtmlInput> _inputs;
        public readonly MyHashTable<string, string> _errors;

        public HtmlForm(RequestMethod method, string action, MyHashTable<string, string> errors = null)
        {
            _method = method;
            _action = action;
            _errors = errors;
            _inputs = new List<HtmlInput>();
        }

        public void AddInput(string name, string value, InputType type = InputType.text)
        {
            HtmlInput input;

            if (type != InputType.text)
            {
                input = new HtmlInput(name, value, type);
            }
            else if (value != "")
            {
                input = new HtmlInput(name, value);
            }
            else
            {
                input = new HtmlInput(name);
            }

            _inputs.Add(input);
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

            begin.Append(Environment.NewLine);
            begin.Append(new HtmlInput("", "clear", InputType.submit).GetTag());
            begin.Append(new HtmlInput("", "submit", InputType.submit).GetTag());
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
}
