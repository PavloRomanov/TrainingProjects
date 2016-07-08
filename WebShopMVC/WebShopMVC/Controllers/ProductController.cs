using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;
using WebShop.Service.Implementation;

namespace WebShopMVC.Controllers
{
    public class ProductController : Controller
    {
        //private IProductService productService;
        private IProductService serviceProduct;

        public ProductController()
        {
           // productService = ServiceLocator.GetProductService();
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IProductService>().To<ProductService>();
            serviceProduct = ninjectKernel.Get<IProductService>();
        }
        //--------------------------------------------------------------------
        /*public ProductController(IProductService serviceproduct)
        {
           serviceProduct = serviceproduct;
        }*/
        //----------------------------------------------------------------------
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListAllProduct()
        {           
            // var model = productService.GetAll();
            var model = serviceProduct.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int Id)
        {
            //var model = productService.GetModelById(Id);
            var model = serviceProduct.GetModelById(Id);
            return View(model);
        }

        [HttpGet]
        public ActionResult ProductsOfSubcategory(int Id)
        {
            // var model = productService.GetProductsOfSubcategory(Id);
            var model = serviceProduct.GetProductsOfSubcategory(Id);
            return View(model);
        }
       
    }
}