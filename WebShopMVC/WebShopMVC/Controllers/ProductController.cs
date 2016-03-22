using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;

namespace WebShopMVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController()
        {
            productService = ServiceLocator.GetProductService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {

            var model = productService.GetAll();
            return View(model);
        }
//----------------------------------------------------
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductViewModel();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                productService.Create(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
//----------------------------------------------------------------
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model= productService.GetModelById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                productService.Update(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
//------------------------------------------------------------------------------
        public ActionResult Delete(ProductViewModel model)
        {
            productService.Delete(model.ProductId);            
            return RedirectToAction("Index", "Home");
        }
    }
    }