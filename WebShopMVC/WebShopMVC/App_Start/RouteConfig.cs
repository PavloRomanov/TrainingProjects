using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebShopMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

             routes.MapRoute(
                 name: "Defaults",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
           
          /*  routes.MapRoute(
                    "HomeRout",
                   "App/{action}/{id}", new {controller="Home "}, new[] { "WebShopMVC.Controllers " });*/

           /* routes.MapRoute(
                    "MainProductRout",
                   "App/{action}/{id}", new { controller = "Product " }, new[] { "WebShopMVC.Controllers" });*/
        }
    }
}
