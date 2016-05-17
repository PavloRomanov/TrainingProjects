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
    public class CartItemController : Controller
    {
        private ICartItemService cartService;
        public CartItemController()
        {
            cartService = ServiceLocator.GetCartItemService();
        }
        public ActionResult AddToCart(int productId, int quantity)
        {
            cartService.AddItem(productId, quantity);
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