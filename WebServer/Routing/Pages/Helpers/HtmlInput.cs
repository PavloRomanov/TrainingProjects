using System;
using System.Text;
using CollectionLibrary;
namespace Routing.Pages.Helpers
{
    public class HtmlInput
    {
        private InputType _type;
        private string _name;
        private string _value;       

        public HtmlInput(string name)   
            :this(name, null)         
        {           
        }

        public HtmlInput(string name, string value)
            : this(name, value, InputType.text)
        {
        }

        public HtmlInput(string name, string value, InputType type)
        {
            _type = type;
            _name = name;
            _value = value;
        }

        public string GetTag(MyHashTable<string, string> errors = null)
        {
            StringBuilder tag = new StringBuilder(Environment.NewLine);

            tag.Append("<br/>" + _name + ":<br/>");
            tag.Append(Environment.NewLine);
            tag.Append("<input type='").Append(_type).Append("' ");
            if (_name != null)
                tag.Append("name='").Append(_name).Append("' ");
            if(_value != null)
                tag.Append("value='").Append(_value).Append("' ");

            if (errors != null)
            {
                if (errors.ContainsKey(_name))
                {
                    tag.Append("style='border-color:red'");
                }
            }

            tag.Append("/>");
          
            if (errors != null)
            {
                if(errors.ContainsKey(_name))
                {                    
                    string message = errors[_name];
                    tag.Append("<span style = 'color:red'>").Append(message).Append("</span>");
                }
            }
            tag.Append(Environment.NewLine);            

            return tag.ToString();
        }
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
