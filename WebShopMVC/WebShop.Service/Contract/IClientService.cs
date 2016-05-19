using System;
using WebShop.Model.Entities;
using System.Collections.Generic;
using WebShop.Model.ViewModel;

namespace WebShop.Service.Contract
{
    public interface IClientService
    { 
        IEnumerable<ClientViewModel> GetAll();
        ClientViewModel GetModelById(int id);
        ClientViewModel GetClientByLoginAndPassword(string login, string password);
        void Create(ClientViewModel model);
        void Update(ClientViewModel model);
        void Delete(int id);
    }
}
