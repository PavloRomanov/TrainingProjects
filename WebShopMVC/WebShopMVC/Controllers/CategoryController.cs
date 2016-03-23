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
            var model = categoryService.GetAll();
            return View(model);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            var model = new CategoryViewModel();
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                categoryService.Create(model);
                return RedirectToAction("List", "Category");
            }
            return View(model);
                       
        }

        // GET: Category/Update/5
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = categoryService.GetModelById(id);
            return View(model);
        }

        // POST: Category/Update/5
        [HttpPost]
        public ActionResult Update(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                categoryService.Update(model);
                return RedirectToAction("List", "Category");
            }
            return View(model);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            categoryService.Delete(id);
            return RedirectToAction("List", "Category");
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(CategoryViewModel model)
        {
            try
            {
                categoryService.Delete(model.CategoryId);
                return RedirectToAction("List", "Category");
            }
            catch
            {
                return View();
            }
        }
    }
}
