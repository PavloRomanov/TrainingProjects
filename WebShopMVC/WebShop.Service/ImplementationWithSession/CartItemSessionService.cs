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
    public class CartItemSessionService : ICartItemSessionService
    {
        public void AddItem(int productId, int quantity)
        {
            List<PartCartItemViewModel> cart;
            PartCartItemViewModel item = new PartCartItemViewModel
            {
                ProductId = productId,
                Quantity = quantity
            };
            HttpContext context = HttpContext.Current;
            if (context.Session["Cart"] == null)
            {
                cart = new List<PartCartItemViewModel>();
            }
            else
            {
                cart = (List<PartCartItemViewModel>)(context.Session["Cart"]);
            }
            cart.Add(item);
            context.Session["Cart"] = cart;
        }

        public void ClearCart()
        {
            HttpContext context = HttpContext.Current;
            List<PartCartItemViewModel> cart = (List<PartCartItemViewModel>)(context.Session["Cart"]);
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
                var cart = (List<PartCartItemViewModel>)(context.Session["Cart"]);
                List<CartItemViewModel> list = new List<CartItemViewModel>();
                List<ProductViewModel> products = new List<ProductViewModel>();
                foreach (var item in cart)
                {
                    using (var contextBd = new WebShopMVCContext())
                    {
                        ProductViewModel product = contextBd.Products.Select(p => new ProductViewModel
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            SubcategoryId = p.SubcategoryId,
                            Price = p.Price,
                            Discount = p.Discount,
                            Description = p.Description,
                        }).Where(p => p.ProductId == item.ProductId).SingleOrDefault();

                        products.Add(product);
                    }

                    foreach (var product in products)
                    {
                        if (product.ProductId == item.ProductId)
                        {
                            CartItemViewModel cartitem = new CartItemViewModel
                            {
                                ProductId = product.ProductId,
                                Product = product,
                                Quantity = item.Quantity
                            };
                            list.Add(cartitem);
                        }
                    }
                }

                return list;
            }
        }

        public void RemoveUnit(int Id)
        {
            HttpContext context = HttpContext.Current;
            List<PartCartItemViewModel> cart = (List<PartCartItemViewModel>)(context.Session["Cart"]);
            var item = cart.Find(x => x.ProductId == Id);
            cart.Remove(item);
            context.Session["Cart"] = cart;
        }
    }
}

