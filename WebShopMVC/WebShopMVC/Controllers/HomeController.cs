using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model.ViewModel;
using System.Web.Security;
using System.Security.Principal;
using System.Web.Optimization;
using System.Web.Routing;
using WebShopMVC;



namespace WebShopMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           /* HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null || authCookie.Value == "")
                return View(); 

            FormsAuthenticationTicket authTicket;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch
            {
                return View(); ;
            }

            // retrieve roles from UserData
            string[] names = authTicket.UserData.Split(',');

            foreach (var el in names)
            {
                ViewBag.Greeting += el + " ";
            }*/
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            return View();
        }


    }
}