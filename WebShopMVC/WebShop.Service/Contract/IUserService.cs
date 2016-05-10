using System;
using System.Collections.Generic;
using WebShop.Model.ViewModel;

namespace WebShop.Service.Contract
{
    public interface IUserService
    {
        UserViewModel GetUserByLogin(string login);
        UserViewModel GertUserByEmail(string email);
        UserViewModel GetUserByLoginAndPassword(string login, string password);
        void Create(UserViewModel model);
        void Update(UserViewModel model);
    }
}
