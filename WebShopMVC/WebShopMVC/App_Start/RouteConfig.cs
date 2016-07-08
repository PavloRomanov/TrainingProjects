using System.Web.Mvc;
using System.Web.Routing;

namespace WebShopMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                 name: null,
                 url: "Page{page}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "WebShopMVC.Controllers" }
                 );
            routes.MapRoute(
                name: "Defaults",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional},
                namespaces:new[] { "WebShopMVC.Controllers"}
                );
        }
    }
}
