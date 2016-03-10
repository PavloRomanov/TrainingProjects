
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Routing.Pages.Helpers
{
    public class HtmlForm : HtmlBaseTag
    {
        public readonly IDictionary<string, string> _errors;

        public HtmlForm(RequestMethod method, string action, IDictionary<string, string> errors = null)
            :base("form", null)
        {
            SetAttribut("name", "form");
            SetAttribut("method", method.ToString());
            SetAttribut("action", action);
            SetAttribut("onsubmit", "return FormIsValid()");
            _errors = errors;            
        }

        public string ToString(IDictionary<string, string> errors)
        {
            StringBuilder form = new StringBuilder(Environment.NewLine);
            form.Append(Environment.NewLine);
            form.Append("<div class='form'>");
            form.Append(Environment.NewLine);
            form.Append(GetTag(errors));
            form.Append(Environment.NewLine);
            form.Append("</div>");
                        
            return form.ToString();
        }
    }
}
