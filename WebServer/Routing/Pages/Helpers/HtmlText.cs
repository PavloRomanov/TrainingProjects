using System;
using System.Collections.Generic;


namespace Routing.Pages.Helpers
{
    public class HtmlText : IHtmlElement
    {
        private string _text;

        public HtmlText(string text)
        {
            _text = text;
        }

        public string GetTag(IDictionary<string, string> errors = null)
        {
            return _text;
        }
    }
}
