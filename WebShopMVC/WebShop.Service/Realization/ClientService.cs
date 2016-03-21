using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Model;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;
using WebShop.Service.Contract;

namespace WebShop.Service.Realization
{
    public class ClientService : IClientService
    {
        public void Create(ClientViewModel model)
        {
            Client client = new Client
            {
                ClientId = model.ClientId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Login = model.Login,
                Password = model.Password,   //.GetHashCode().ToString(),
                Email = model.Email,
                Phone = model.Phone
            };

            using (var context = new WebShopMVCContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            var model = new List<ClientViewModel>();
            using (var context = new WebShopMVCContext())
            {
                model = context.Clients.Select(m => new ClientViewModel
                {
                    ClientId = m.ClientId,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Login = m.Login,
                    Password = m.Password,
                    Email = m.Email,
                    Phone = m.Phone
                }).ToList();
            }
            return model;
        }

        public void Delete(int id)
        {
            using (var context = new WebShopMVCContext())
            {
                context.Clients.Remove(
                    context.Clients.Where(m => m.ClientId == id).FirstOrDefault());
                context.SaveChanges();
            }
        }
       
        public ClientViewModel GetModelById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
