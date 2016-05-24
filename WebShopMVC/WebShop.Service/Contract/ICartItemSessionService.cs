using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;

namespace WebShop.Service.Contract
{
   public interface ICartItemSessionService
    {
        void AddItem(ProductViewModel product, int quantity);
        void RemoveUnit(int Id);
        void ClearCart();
        IEnumerable<CartItemViewModel> GetCartFromSession();
    }
}
