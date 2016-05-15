using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;

namespace WebShopMVC.Controllers
{
    public class CartController : Controller
    {
        private ICartService cartService;
        public CartController()
        {
            cartService = ServiceLocator.GetCartService();
        }
        public ActionResult AddToCart(Product product, int quantity)
        {
            cartService.AddItem(product, quantity);
            return RedirectToAction("List", "Cart"); ;
        }

        public ActionResult DeleteAll()
        {
            cartService.ClearCart();
            return RedirectToAction("List", "Cart"); ;
        }
        public ActionResult Delete(int productId)
        {
            cartService.RemoveUnit(productId);
            return RedirectToAction("List", "Cart");
        }
        public ActionResult TotalSum()
        {
            cartService.TotalAmountOfPurchases();
            return RedirectToAction("List", "Cart");
        }
        public ActionResult List()
        {
          
            return View();
        }
    }
}