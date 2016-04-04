using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;

namespace WebShopMVC.Areas.Admin.Controllers
{
    public class SubcategoryController : Controller
    {
        private ISubcategoryService subcategoryService;

        public SubcategoryController()
        {
            subcategoryService = ServiceLocator.GetSubcategoryService();
        }

        // GET: Subcategory
        public ActionResult List()
        {
            var model = subcategoryService.GetAll();
            return View(model);
        }

        // GET: Subcategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Subcategory/Create
        public ActionResult Create()
        {
            var model = subcategoryService.GetNewSubcategoryViewModelWithCategories();
            return View(model);
        }

        // POST: Subcategory/Create
        [HttpPost]
        public ActionResult Create(CompositeSubcategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                subcategoryService.Create(model);
                return RedirectToAction("List", "Subcategory");
            }
            return View(model);

        }

        // GET: Subcategory/Update/5
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = subcategoryService.GetModelById(id);
            return View(model);
        }

        // POST: Subcategory/Update/5
        [HttpPost]
        public ActionResult Update(SubcategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                subcategoryService.Update(model);
                return RedirectToAction("List", "subcategory");
            }
            return View(model);
        }

        // GET: Subcategory/Delete/5
        public ActionResult Delete(int id)
        {
            subcategoryService.Delete(id);
            return RedirectToAction("List", "subcategory");
        }

        // POST: Subcategory/Delete/5
        [HttpPost]
        public ActionResult Delete(SubcategoryViewModel model)
        {
            try
            {
                subcategoryService.Delete(model.SubcategoryId);
                return RedirectToAction("List", "Subcategory");
            }
            catch
            {
                return View();
            }
        }

    }
}