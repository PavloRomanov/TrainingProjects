using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Service;
using WebShop.Service.Contract;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;
using WebShop.Service.Implementation;

namespace WebShopMVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController()
        {
            employeeService = ServiceLocator.GetEmployeeService();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var model = new EmployeeViewModel();
            model.ListOfRoles = new Dictionary<int, string>();
            
            model.ListOfRoles.Add((int)Role.None, Role.None.ToString());
            model.ListOfRoles.Add((int)Role.Admin, Role.Admin.ToString());
            model.ListOfRoles.Add((int)Role.Manager, Role.Manager.ToString());
            model.ListOfRoles.Add((int)Role.Accountant, Role.Accountant.ToString());
            model.ListOfRoles.Add((int)Role.SupportService, Role.SupportService.ToString());

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Update(int id)
        {
            var model = employeeService.GetEmployeeById(id);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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