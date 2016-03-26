using System.Web.Mvc;

namespace WebShopMVC.Areas.admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },new[] { "WebShopMVC.Controllers" }
            );

            context.MapRoute(
                    "ProductRout",
                   "App/{action}/{id}", new { controller = "Product " }, new[] { "WebShopMVC.Controllers" });
        }
    }
}