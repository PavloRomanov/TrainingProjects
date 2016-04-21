using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;

namespace WebShopMVC.Controllers
{
    public class ImageController : Controller
    {

        private IImageService imageService;


        public ImageController()
        {
            imageService = ServiceLocator.GetImageService();
        }
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }
        public FileContentResult Image(int productId )
        {

            using (var context = new WebShopMVCContext())
            {
                var image = context.Images.FirstOrDefault(p => p.ProductId == productId);

                if (image != null)
                {
                    return File(image.Picture, image.ImageMineType);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}