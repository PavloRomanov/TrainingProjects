using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Service;
using WebShop.Service.Contract;

namespace WebShopMVC.Controllers
{
    public class SubcategoryController : Controller
    {
        private ISubcategoryService subService;

        public SubcategoryController()
        {
            subService = ServiceLocator.GetSubcategoryService();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Subcategories
        public ActionResult ListSubcategories()
        {
            var model = subService.GetAll();

            return View("ListSubcategory", model);
        }
        
    }
}