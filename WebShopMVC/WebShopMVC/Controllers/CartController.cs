using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

    }
}