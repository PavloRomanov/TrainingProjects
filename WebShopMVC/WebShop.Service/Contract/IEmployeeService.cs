using System;
using System.Collections.Generic;
using WebShop.Model.ViewModel;

namespace WebShop.Service.Contract
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeViewModel> GetAllEmployee();
        EmployeeViewModel GetEmployeeByLoginAndPassword(string login, string password);
        EmployeeViewModel GetEmployeeById(int id);
        void Create(EmployeeViewModel model);
        void Update(EmployeeViewModel model);
        void Delete(int id);
    }
}
