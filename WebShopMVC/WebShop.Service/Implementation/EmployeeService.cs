﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Model;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;
using WebShop.Service.Contract;

namespace WebShop.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        public void Create(EmployeeViewModel model)
        {
            Employee employee = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Login = model.Login,
                Password = model.Password,
                Address = model.Address,
                Email = model.Email,
                Phone = model.Phone,                
                Role = model.Role,
                IsBlocked = model.IsBlocked,
                IsDelete = model.IsDelete,
                RowVersion = model.RowVersion
            };

            using (var context = new WebShopMVCContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            var model = new List<EmployeeViewModel>();

            using (var context = new WebShopMVCContext())
            {
                model = context.Employees.Select(m => new EmployeeViewModel
                {
                    UserId = m.UserId,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Address = m.Address,
                    Email = m.Email,
                    Phone = m.Phone,
                    Login = m.Login,
                    Password = m.Password,
                    Role = m.Role,
                    IsBlocked = m.IsBlocked,
                    IsDelete = m.IsDelete,
                    RowVersion = m.RowVersion
                }).ToList();
            }
            return model;
        }

        public EmployeeViewModel GetEmployeeById(int id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            using (var context = new WebShopMVCContext())
            {
                var employee = context.Employees.Find(id);

                model.UserId = id;
                employee.FirstName = model.FirstName;
                model.LastName = employee.LastName;
                model.Address = employee.Address;
                model.Email = employee.Email;
                model.Phone = employee.Phone;
                model.Login = employee.Login;
                model.Password = employee.Password;
                model.Role = employee.Role;
                model.IsBlocked = employee.IsBlocked;
                model.IsDelete = employee.IsDelete;
                model.RowVersion = employee.RowVersion;
            }
            return model;
        }

        public EmployeeViewModel GetEmployeeByLoginAndPassword(string login, string password)
        {
            EmployeeViewModel model;
            using (var context = new WebShopMVCContext())
            {
                model = context.Employees.Where(m => m.Login == login && m.Password == password)
                    .Select(m => new EmployeeViewModel
                    {
                        UserId = m.UserId,
                        Login = m.Login,
                        Email = m.Email,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        Phone = m.Phone,
                        Address = m.Address,
                        Role = m.Role,
                        IsBlocked = m.IsBlocked,
                        IsDelete = m.IsDelete,
                        RowVersion = m.RowVersion
                    }).SingleOrDefault();
            }
            return model;
        }

        public void Update(EmployeeViewModel model)
        {
            using (var context = new WebShopMVCContext())
            {
                var employee = context.Employees.Find(model.UserId);

                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Address = model.Address;
                employee.Email = model.Email;
                employee.Phone = model.Phone;
                employee.Login = model.Login;
                employee.Password = model.Password;
                employee.Role = model.Role;
                employee.IsBlocked = model.IsBlocked;
                employee.IsDelete = model.IsDelete;
                employee.RowVersion = model.RowVersion;

                context.SaveChanges();
            }
        }

       
    }
}
