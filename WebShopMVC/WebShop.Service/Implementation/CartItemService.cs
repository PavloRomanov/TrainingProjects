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

        List<CartItemViewModel> Cart;

        public void AddItem(int productId, int quantity)
        {
            using (var context = new WebShopMVCContext())
            {
                Cart = context.CartItems.Select(m => new CartItemViewModel
                {
                    ProductId = m.ProductId,
                    ClientId = m.ClientId,
                    Product = m.Product,
                    Quantity = m.Quantity
                }).ToList();
                CartItemViewModel line = Cart
                        .Where(p => p.ProductId == productId)
                        .FirstOrDefault();
                if (line == null)
                {
                    Cart.Add(new CartItemViewModel { ProductId = productId, Quantity = quantity });
                }
                else
                {
                    line.Quantity += quantity;
                }

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
                    ClientId = m.ClientId,
                    ProductId = m.ProductId,
                    Product = m.Product,
                    Quantity = m.Quantity     
                }).ToList();
            }
            return list;
        }

        public void RemoveUnit(int Id)
        {
            Cart.RemoveAll(r => r.ProductId == Id);
        }

        public decimal TotalAmountOfPurchases()
        {
            return Cart.Sum(s => s.Product.Price * s.Quantity);
        }
    }
}
