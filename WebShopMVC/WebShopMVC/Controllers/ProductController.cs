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


        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListAllProduct()
        {
            var model = productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int Id)
        {
            var model = productService.GetModelById(Id);
            return View(model);
        }

        [HttpGet]
        public ActionResult ProductsOfSubcategory(int Id)
        {

            var model = productService.GetProductsOfSubcategory(Id);
           
            return View(model);
        }
    }
}