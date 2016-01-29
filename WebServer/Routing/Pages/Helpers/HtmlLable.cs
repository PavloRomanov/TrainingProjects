using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routing.Pages.Helpers
{
    public class HtmlLable : HtmlBaseTag
    {
        public HtmlLable(string text)
            : base("lable", text)
        {
        }

        protected override string GetTagEnd()
        {            
            return "</lable>";
        }
    }
}
