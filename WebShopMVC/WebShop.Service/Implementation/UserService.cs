using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Model;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;
using WebShop.Service.Contract;

namespace WebShop.Service.Implementation
{
    public class UserService : IUserService
    {
         public void Create(UserViewModel model)
         {
             User user = new User
             {
                 UserId = model.UserId,
                 Login = model.Login,
                 Password = model.Password,
                 Email = model.Email,
                 IsEmployee = false
             };

             using (var context = new WebShopMVCContext())
             {
                 context.Users.Add(user);
                 context.SaveChanges();
             }
         }

         public UserViewModel GertUserByEmail(string email)
         {
             UserViewModel model;

             using (var context = new WebShopMVCContext())
             {
                 model = context.Users.Where(m => m.Email == email)
                    .Select(m => new UserViewModel
                 {
                     UserId = m.UserId,
                     Email = m.Email,
                     Login = m.Login,
                     Password = m.Password,
                     IsEmployee = m.IsEmployee
                 }).SingleOrDefault();
             }
             return model;
         }

        public UserViewModel GetUserByLoginAndPassword(string login, string password)
        {
            UserViewModel model;
            using (var context = new WebShopMVCContext())
            {
                model = context.Users.Where(m => m.Login == login && m.Password == password && m.IsEmployee == true)
                    .Select(m => new UserViewModel
                    {
                        UserId = m.UserId,
                        Login = m.Login,
                        Email = m.Email,
                        IsEmployee = m.IsEmployee
                    }).SingleOrDefault();
            }
            return model;
        }

         public UserViewModel GetUserByLogin(string login)
         {
             UserViewModel model;
             using (var context = new WebShopMVCContext())
             {
                 model = context.Users.Select(m => new UserViewModel
                 {
                     UserId = m.UserId,
                     Email = m.Email,
                     Login = m.Login,
                     Password = m.Password,
                     IsEmployee = m.IsEmployee
                 }).Where(m => m.Login == login).SingleOrDefault();
             }
             return model;
         }

         public void Update(UserViewModel model)
         {
             using (var context = new WebShopMVCContext())
             {
                 var user = context.Users.Find(model.UserId);

                 user.Login = model.Login;
                 user.Password = model.Password;
                 user.Email = model.Email;
                 user.IsEmployee = false;

                 context.SaveChanges();
             }
         }
    }
}
