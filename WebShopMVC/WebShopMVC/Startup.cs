using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShopMVC.Startup))]
namespace WebShopMVC
{
    //https://msdn.microsoft.com/ru-ru/data/jj193542.aspx

    //Code first migration commands:
    //http://www.mortenanderson.net/code-first-migrations-for-entity-framework
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
