using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model.ViewModel;
namespace WebShopMVC.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductViewModel();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            
            return View("Create",model);
        }

       /* [HttpGet]
         public ActionResult Update(ProductViewModel model)
         {
         var remodel = model;
             return View("Update", remodel);
         }

         [HttpPost]
         public ActionResult Update(ProductViewModel model)
         {

             return View("Index", model);
         }*/
    }
}