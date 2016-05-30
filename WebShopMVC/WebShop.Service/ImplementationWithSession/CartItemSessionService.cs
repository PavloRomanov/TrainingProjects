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
        public void AddItem(int productId, int quantity)
        {
            List <CartItemViewModel> cart;
            CartItemViewModel item = new CartItemViewModel
            {
                ProductId = productId,
                Quantity = quantity
            };
            HttpContext context = HttpContext.Current;
            if (context.Session["Cart"]==null)
            {
               cart = new List<CartItemViewModel>();
            }
            else
            {
                cart = (List<CartItemViewModel>)(context.Session["Cart"]);
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
        public IEnumerable<CartItemViewModel> GetCartFromSession()
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["Cart"] == null)
            {
                return null;
            }
            else
            {
                var cart = (List<CartItemViewModel>)(context.Session["Cart"]);

                var list = new List<Product>();
                foreach (var item in cart)
                {
                    using (var contextBd = new WebShopMVCContext())
                    {
                        list = contextBd.Products.Select(m => new Product
                        {
                            ProductId = m.ProductId,
                            ProductName = m.ProductName,
                            Price = m.Price,
                            Discount = m.Discount
                        }).Where(p => p.ProductId == item.ProductId).ToList();///???
                    }
                }

                foreach (var item in cart)
                {
                    foreach (var product in list)
                    {
                        if (item.ProductId == product.ProductId)
                        {
                            item.Product.ProductName = product.ProductName;///////////////////////?????
                            item.Product.Price = product.Price;
                            item.Product.Discount = product.Discount;
                            break;
                        }
                    }
                }
                return cart;
            }

        }

        public void RemoveUnit(int Id)
        {
            HttpContext context = HttpContext.Current;
            List<CartItemViewModel> cart = (List<CartItemViewModel>)(context.Session["Cart"]);
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

