using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;


namespace WebShopMVC.Controllers
{
    public class ClientController : Controller
    {
        private IClientService clientService;

        public ClientController()
        {
            clientService = ServiceLocator.GetClientService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var model = clientService.GetAll();
            return View(model);
        }

        //--Create--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ClientViewModel();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ClientViewModel model)
        {
            if(ModelState.IsValid)
            {
                clientService.Create(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        //--Update--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //--Delete--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}