using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model;
using WebShop.Model.Entities;
using WebShop.Model.ViewModel;
using WebShop.Service.Contract;

namespace WebShop.Service.Implementation
{
    public class ImageService : IImageService
    {
        public void Create(ImageViewModel model)
        {
            Image picture = new Image
            {
            ImageId= model.ImageId,
            ProductId = model.ProductId,
            FileName = model.FileName,
            Picture = new byte [model.Image.ContentLength],
            ImageMineType = model.Image.ContentType,
            MainPicture = model.MainPicture

        };
            using (var context = new WebShopMVCContext())
            {
                 context.Images.Add(picture);
                 context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var context = new WebShopMVCContext())
            {
                var picture = context.Images.Find(id);
                context.Images.Remove(picture);
                context.SaveChanges();
            }
        }
    }
}