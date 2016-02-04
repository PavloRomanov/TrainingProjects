using System;
using System.Collections.Generic;

namespace Routing.Pages
{
    public interface IBasePage
    {
        Response Get(IDictionary<string, string> form, string sessionId = null, IDictionary<string, string> errors = null);
        Response Post(IDictionary<string, string> form, string sessionId = null);
    }
}
