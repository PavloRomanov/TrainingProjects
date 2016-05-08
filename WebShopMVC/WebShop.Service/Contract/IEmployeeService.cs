using System;
using System.Collections.Generic;
using WebShop.Model.ViewModel;

namespace WebShop.Service.Contract
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeViewModel> GetAllEmployee();
        EmployeeViewModel GetEmployeeById(int id);
        void Create(EmployeeViewModel model);
        void Update(EmployeeViewModel model);
        void Delete(int id);
    }
}
