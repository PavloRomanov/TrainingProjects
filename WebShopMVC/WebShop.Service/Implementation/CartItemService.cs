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
            if (clientId != null)
            {
                using (var context = new WebShopMVCContext())
                {
                    context.CartItems.Add(item);
                    context.SaveChanges();
                }
            }
            else
            {
                HttpContext context = HttpContext.Current;
                List < CartItem> cart = (List<CartItem>)(context.Session["Cart"]);
               // context.Session["Cart"] = cart.Add(item);  //?????????????????????????      
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
        public IEnumerable<CartItemViewModel> GetCart()
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
          
            using (var context = new WebShopMVCContext())
            {
                var product = context.CartItems.Find(Id);             
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
