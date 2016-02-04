
using System.Collections.Generic;


namespace Routing.Pages.Helpers
{
    public interface IHtmlElement
    {
        string GetTag(IDictionary<string, string> errors = null);
    }
}
