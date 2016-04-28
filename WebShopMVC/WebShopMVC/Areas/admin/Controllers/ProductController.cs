using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model;
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
        public ActionResult Details(int Id)
        {
           // var model = productService.GetModelById(Id);
            return RedirectToAction("List", "Product");
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

        public FileContentResult Image(int productId)
        {

            using (var context = new WebShopMVCContext())
            {
                var image = context.Images.FirstOrDefault(p => p.ProductId == productId);

                if (image != null)
                {
                    return File(image.Picture, image.ImageMineType);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}