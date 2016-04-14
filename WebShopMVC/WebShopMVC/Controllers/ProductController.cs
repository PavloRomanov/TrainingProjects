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
        private ISubcategoryService subService;

        public ProductController()
        {
            productService = ServiceLocator.GetProductService();
            subService = ServiceLocator.GetSubcategoryService();
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
        //------------------------------------------------------------------------------------  
        // GET: Subcategories
        public ActionResult ListSubcategories()
        {
            var model = subService.GetNewSubcategoryViewModelWithCategories();

            return PartialView("_PartialSubcategory", model);
        }
    }
}