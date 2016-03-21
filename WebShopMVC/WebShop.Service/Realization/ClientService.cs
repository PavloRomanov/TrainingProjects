using System;
using System.Collections.Generic;
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            throw new NotImplementedException();
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
