using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;

namespace WebShopMVC.Areas.admin.Controllers
{
    public class ProductController : Controller
    {

        private IProductService productService;

        public ProductController()
        {
            productService = ServiceLocator.GetProductService();
        }

        // GET: admin/Product
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = productService.GetNewProductViewModelWithSubcategory();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                productService.Create(model);
                return RedirectToAction("List", "Product");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = productService.GetModelById(id);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult Update(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {             
                productService.Update(model);
                return RedirectToAction("List", "Product");
            }
            return View(model);
        }
//-------------------------------------------------------------------------------------
        public ActionResult List()
        {
            var model = productService.GetAll();
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            productService.Delete(id);
            return RedirectToAction("List", "Product");
        }
    }
}