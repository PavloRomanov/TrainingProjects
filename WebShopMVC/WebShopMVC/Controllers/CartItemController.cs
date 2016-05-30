using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;
using WebShop.Service.Extension;

namespace WebShopMVC.Controllers
{
    public class CartItemController : Controller
    {
        private ICartItemService cartService;
        private ICartItemSessionService cartItemSessionService;
        public CartItemController()
        {
            cartService = ServiceLocator.GetCartItemService();
            cartItemSessionService = ServiceLocator.GetCartItemSessionService();
        }
        public ActionResult AddToCart(int productId,int quantity=1)
        {
            if (User.GetClientId() != null)
            {
                cartService.AddItem((int)User.GetClientId(), productId, quantity);
                return RedirectToAction("GetCart", "CartItem");
            }
            else
            {
                cartItemSessionService.AddItem(productId, quantity);
                return RedirectToAction("GetCart", "CartItem");
            }
        }
        public ActionResult DeleteAll()
        {
            cartService.ClearCart();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete(int productId)
        {
            cartService.RemoveUnit(productId);
            return RedirectToAction("GetCart", "CartItem");
        }
        public ActionResult GetCart()
        {
            if (User.GetClient().Login != null)
            {
                var model = cartService.GetAllCartItem();
                return View(model);
            }
            else
            {
                var model = cartItemSessionService.GetCartFromSession();
                return View(model);
            }
        }

        /*public ActionResult TotalSum(int quantity, decimal price)
        {
        if(User.GetClient().Login != null)
            {
            cartService.TotalAmountOfPurchases(quantity, price);
            }
            else
            {
            cartItemSessionService.TotalAmountOfPurchases(quantity, price);
            }
            return RedirectToAction("Cart", "CartItem");
        }*/

    }
}