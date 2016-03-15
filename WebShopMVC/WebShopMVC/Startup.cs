using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShopMVC.Startup))]
namespace WebShopMVC
{
    //https://msdn.microsoft.com/ru-ru/data/jj193542.aspx
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
