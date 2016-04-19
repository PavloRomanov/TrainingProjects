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
       /* public byte[] CreatePicture("")
        {
            byte[] pic = new byte[];
            return pic;
        }*/
        public void Create(ImageViewModel model)
        {
            Image product = new Image
            {
                ImageId = model.ImageId,
                ProductId = model.ProductId,
                FileName = model.FileName,
                MainPicture = model.MainPicture,
                Picture = model.Picture
            };
        }

        public void Delete(int id)
        {
            using (var context = new WebShopMVCContext())
            {
                var image = context.Images.Find(id);
                context.Images.Remove(image);
                context.SaveChanges();
            }
        }

        public IEnumerable<ImageViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ImageViewModel GetModelById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ImageViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}