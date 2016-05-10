using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;

namespace WebShopMVC.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController()
        {
            userService = ServiceLocator.GetUserService();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var currentUser = userService.GetUserByLoginAndPassword(model.Login, model.Password);
                if(currentUser != null)
                {
                    var authTicket = new FormsAuthenticationTicket(
                        1,
                        currentUser.Login,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(60),
                        true,
                        null
                        );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильно указан логин или пароль");
                    return View(model);
                }
            }
            return View(model);            
        }

        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
    }
}