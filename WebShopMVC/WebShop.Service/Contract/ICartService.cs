using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;

namespace WebShop.Service.Contract
{
    public interface ICartService
    {
        void AddItem(Product product, int quantity);
        void RemoveUnit(int Id);
        void ClearCart();
        decimal TotalAmountOfPurchases();
        IEnumerable<CartViewModel> GetAll();
    }
}
