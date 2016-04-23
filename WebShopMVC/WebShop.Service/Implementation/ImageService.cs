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
            Picture = model.Picture,
            ImageMineType = model.ImageMineType,
            MainPicture = model.MainPicture
        };
            using (var context = new WebShopMVCContext())
            {
                 context.Images.Add(picture);
                 context.SaveChanges();
            }
        }
        public ImageViewModel GetModelById(int id)
        {
            ImageViewModel model;

            using (var context = new WebShopMVCContext())
            {
                var picture = context.Images.Find(id);
                model = new ImageViewModel
                {
                    ImageId = picture.ImageId,
                    ProductId = picture.ProductId,
                    Picture = picture.Picture,
                    ImageMineType = picture.ImageMineType,
                    MainPicture = picture.MainPicture
                };
            }
            return model;
        }

        public void Update(ImageViewModel model)
        {
            using (var context = new WebShopMVCContext())
            {
                 var picture = context.Images.Find(model.ImageId);
                 picture.ProductId = model.ProductId;
                 picture.Picture = model.Picture;
                 picture.ImageMineType = model.ImageMineType;
                 picture.MainPicture = model.MainPicture;
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