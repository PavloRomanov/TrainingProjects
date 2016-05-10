using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Service;
using WebShop.Service.Contract;
using WebShop.Model.ViewModel;
using WebShop.Service.Implementation;

namespace WebShopMVC.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController()
        {
            employeeService = ServiceLocator.GetEmployeeService();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new EmployeeViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                employeeService.Create(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = employeeService.GetEmployeeById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                employeeService.Update(model);
                return RedirectToAction("List");
            }
            return View(model);
        }

        public ActionResult List()
        {
            IEnumerable<EmployeeViewModel> model = employeeService.GetAllEmployee();
            return View(model);
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
    }
}