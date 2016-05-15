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
    public class CartService : ICartService
    {
        List<Cart> lineCollection = new List<Cart>();//??
        public void AddItem(Product product, int quantity)
        {
            Cart line = lineCollection
                    .Where(p => p.Product.ProductId == product.ProductId)
                    .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new Cart { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void ClearCart()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartViewModel> GetAll()
        {
            var list = new List<CartViewModel>();
            using (var context = new WebShopMVCContext())
            {
                list = context.Carts.Select(m => new CartViewModel
                {
                    CartId = m.CartId,
                    Product = m.Product,
                    ClientId = m.ClientId,
                    Quantity = m.Quantity,     
                }).ToList();
            }
            return list;
        }

        public void RemoveUnit(int Id)
        {
            lineCollection.RemoveAll(r => r.Product.ProductId == Id);
        }

        public decimal TotalAmountOfPurchases()
        {
            return lineCollection.Sum(s => s.Product.Price * s.Quantity);
        }
    }
}
