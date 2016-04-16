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


        public ActionResult ListAllProduct()
        {
            var model = productService.GetAll();
            return View(model);
        }


        public ActionResult GetOneProduct(int Id)
        {
            var model = productService.GetModelById(Id);
            return View(model);
        }
        public ActionResult ProductsOfSubcategory(int Id)
        {

            var mod = productService.GetAll();
            List<ProductViewModel> model= new List<ProductViewModel>();
            foreach (var element in mod)
            {
                if(element.SubcategoryId == Id)
                {
                    model.Add(element);
                }
            }
            return View(model);
        }
    }
}