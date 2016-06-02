using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;

namespace WebShopMVC.Controllers
{
    public class ClientController : Controller
    {
        public readonly IClientService clientService;

        public ClientController()
        {
            clientService = ServiceLocator.GetClientService();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {            
            if (ModelState.IsValid)
            {
                var currentUser = clientService.GetClientByLoginAndPassword(model.Login, model.Password);
                
                if(currentUser != null)
                {
                    string name;
                    if (currentUser.FirstName != null)
                        name = currentUser.FirstName + " " + currentUser.LastName;
                    name = currentUser.Login;
                    
                    var authTicket = new FormsAuthenticationTicket(
                        1,
                        currentUser.UserId.ToString(),
                        DateTime.Now,
                        DateTime.Now.AddMinutes(60),
                        true,
                        name
                        );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Home");
                }                
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        //~~~~~~~~~~~~~~~~~~~~~ CREATE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientViewModel model)
        {
            if(ModelState.IsValid)
            {
                clientService.Create(model);
                return RedirectToAction("Login");
            }
            
            return View(model);
        }

        //~~~~~~~~~~~~~~~~~~~~~ UPDATE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = clientService.GetModelById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                clientService.Update(model);
                return RedirectToAction("List", "Client");
            }
            return View(model);
        }

        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
    }
}