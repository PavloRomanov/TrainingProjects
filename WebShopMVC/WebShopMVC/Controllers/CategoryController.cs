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
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;

        public CategoryController()
        {
            categoryService = ServiceLocator.GetCategoryService();
        }

        // GET: Category
        public ActionResult List()
        {
            var model = categoryService.GetAllWithSubcategory();

            return PartialView("_PartialCategory", model);
        }
    }
}