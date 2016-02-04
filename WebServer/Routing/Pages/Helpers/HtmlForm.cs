//using CollectionLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Routing.Pages.Helpers
{
    public class HtmlForm : HtmlBaseTag
    {
        //public readonly List<HtmlBaseTag> _tags;
        public readonly IDictionary<string, string> _errors;

        public HtmlForm(RequestMethod method, string action, IDictionary<string, string> errors = null)
            :base("form", null)
        {
            SetAttribut("name", "form");
            SetAttribut("method", method.ToString());
            SetAttribut("action", action);
            SetAttribut("onsubmit", "return validateForm()");            
            _errors = errors;            
        }

        
        public override HtmlBaseTag AddTag(string name, string text = null)
        {
           
            HtmlBaseTag tag = new HtmlBaseTag(name, text);
            TagContent.Add(tag);
             return tag;
        }

        //удалить метод!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
        public HtmlSelect AddSelect(string name, IDictionary<string,string> options)
        {

            HtmlSelect select = new HtmlSelect(name, options);

            TagContent.Add(select);
            
            return select;
        }

        public string ToString(IDictionary<string, string> errors)
        {            
            return GetTag(errors);
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
