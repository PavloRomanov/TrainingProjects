using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model;
using WebShop.Model.ViewModel;
using WebShop.Service;
using WebShop.Service.Contract;
using WebShop.Service.Implementation;

namespace WebShopMVC.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        private IImageService imageService;
        public ImageController()
        {
            imageService = ServiceLocator.GetImageService();
        }

        // GET: Admin/Image
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ImageViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                imageService.Create(model);
                return RedirectToAction("List", "Image");//??
            }         
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            imageService.Delete(id);
            return RedirectToAction("List", "Image");//??
        }
        //------------------------------------------------------------------------
        public FileContentResult GetImage(int productId)
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