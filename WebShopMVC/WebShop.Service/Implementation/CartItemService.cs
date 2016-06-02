using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebShop.Model;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;
using WebShop.Service.Contract;

namespace WebShop.Service.Implementation
{
    public class CartItemService : ICartItemService
    {
        public void AddItem(int clientId, int productId, int quantity)
        {
            CartItem item = new CartItem
            {
                ProductId = productId,
                ClientId = clientId,
                Quantity = quantity
            };
            using (var context = new WebShopMVCContext())
            {
                context.CartItems.Add(item);
                context.SaveChanges();
            }
        }
        public void ClearCart()
        {
            var list = new List<CartItem>();
            using (var context = new WebShopMVCContext())
            {
                list = context.CartItems.Select(m => new CartItem
                {
                    CartItemId = m.CartItemId,
                    ClientId = m.ClientId,
                    Client = m.Client,
                    ProductId = m.ProductId,
                    Product = m.Product,
                    Quantity = m.Quantity
                }).ToList();
                context.CartItems.RemoveRange(list);
                context.SaveChanges();
            }
        }
        public IEnumerable<CartItemViewModel> GetAllCartItem()
        {
            var list = new List<CartItemViewModel>();
            using (var context = new WebShopMVCContext())
            {
                list = context.CartItems.Select(m => new CartItemViewModel
                {
                    CartItemId = m.CartItemId,
                    ClientId = m.ClientId,
                    ProductId = m.ProductId,
                    Product = context.Products.Select(p => new ProductViewModel//??
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        SubcategoryId = p.SubcategoryId,
                        Price = p.Price,
                        Discount = p.Discount,
                        Description = p.Description,
                    }).Where(p => p.ProductId == m.ProductId).SingleOrDefault(),
                    Quantity = m.Quantity
                }).ToList();
            }
            return list;
        }

        public void RemoveUnit(int productId)
        {
          
            using (var context = new WebShopMVCContext())
            {
                var product = context.CartItems.Find(productId);             
                context.CartItems.Remove(product);
                context.SaveChanges();
            }
        }
      /*  public decimal TotalAmountOfPurchases()
        {
            return Cart.Sum(s => s.Product.Price * s.Quantity);
        }*/
    }
}
