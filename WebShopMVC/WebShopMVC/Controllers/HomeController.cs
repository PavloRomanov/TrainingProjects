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
using WebShop.Service.Extension;



namespace WebShopMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(User.GetClientId() != null)
            {
                ClientViewModel client = User.GetClient();
                Session["ClientName"] = client.FirstName + " " + client.LastName;
                ViewBag.ClientName = Session["ClientName"];
            }           
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