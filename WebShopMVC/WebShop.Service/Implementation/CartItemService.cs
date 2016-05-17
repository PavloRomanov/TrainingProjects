using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;
using WebShop.Service.Contract;

namespace WebShop.Service.Implementation
{
    public class CartItemService : ICartItemService
    {
        List<CartItem> Cart = new List<CartItem>();
        public void AddItem(int productId, int quantity)
        {
            CartItem line = Cart
                    .Where(p => p.Product.ProductId == productId)
                .FirstOrDefault();
            if (line == null)
            {
                Cart.Add(new CartItem { ProductId = productId, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void ClearCart()
        {
            Cart.Clear();
        }

        public IEnumerable<CartItemViewModel> GetAll()
        {
            var list = new List<CartItemViewModel>();
            using (var context = new WebShopMVCContext())
            {
                list = context.CartItems.Select(m => new CartItemViewModel
        {
                    CartItemId = m.CartItemId,
                    ProductId = m.ProductId,
                    ClientId = m.ClientId,
                    Quantity = m.Quantity,     
                }).ToList();
            }
            return list;
        }

        public void RemoveUnit(int Id)
        {
            Cart.RemoveAll(r => r.Product.ProductId == Id);
        }

        public decimal TotalAmountOfPurchases()
        {
            return Cart.Sum(s => s.Product.Price * s.Quantity);
        }
    }
}