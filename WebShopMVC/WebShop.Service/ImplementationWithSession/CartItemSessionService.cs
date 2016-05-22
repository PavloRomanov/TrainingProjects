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

namespace WebShop.Service.UsingSession
{
   public class CartItemSessionService: ICartItemSessionService
    {
        public void AddItem(int clienId,int productId, int quantity = 1)
        {
            List<CartItem> cart;
            CartItem item = new CartItem
            {
                ProductId = productId,
                ClientId = clienId,
                Quantity = quantity
            };
            HttpContext context = HttpContext.Current;
            if (context.Session["Cart"]==null)
            {
               cart = new List<CartItem>();
            }
            else
            {
                cart = (List<CartItem>)(context.Session["Cart"]);
            }
            cart.Add(item);
            context.Session["Cart"] = cart;
        }

        public void ClearCart()
        {
            HttpContext context = HttpContext.Current;
            List<CartItem> cart=(List<CartItem>)(context.Session["Cart"]);
            cart.Clear();
            context.Session["Cart"] = cart;
        }

        public IEnumerable<CartItem> GetCartFromSession()//???
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["Cart"] == null)
            {
                return null;
            }
            else
            {
                List<CartItem> cart = (List<CartItem>)(context.Session["Cart"]);
                return cart;
            }
        }

        public void RemoveUnit(int Id)
        {
            HttpContext context = HttpContext.Current;
            List<CartItem> cart = (List<CartItem>)(context.Session["Cart"]);
            var item = cart.Find(x=> x.ProductId== Id);
            cart.Remove(item);
            context.Session["Cart"] = cart;
        }
        /*  public decimal TotalAmountOfPurchases()
          {
              return Cart.Sum(s => s.Product.Price * s.Quantity);
          }*/
    }
}

