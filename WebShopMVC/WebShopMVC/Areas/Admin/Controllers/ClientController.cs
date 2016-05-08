using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;

namespace WebShopMVC.Areas.Admin.Controllers
{
    public class ClientController// : Controller
    {
       /* private IClientService clientService;

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
            if (ModelState.IsValid)
            {
                clientService.Create(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        //--Update--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

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
        }*/

        //--Delete--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}
