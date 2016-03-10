using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShopMVC.Startup))]
namespace WebShopMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
