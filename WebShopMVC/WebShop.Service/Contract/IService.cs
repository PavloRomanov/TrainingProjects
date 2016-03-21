using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Model.ViewModel;

namespace WebShop.Service.Contract
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetModelById(int id);
        void Create(T model);
        void Update(T model);
        void Delete(int id);
    }
}
