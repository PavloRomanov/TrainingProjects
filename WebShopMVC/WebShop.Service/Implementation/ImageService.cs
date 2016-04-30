using System;
using System.Collections.Generic;
using System.IO;
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
        public void Create(MainImageViewModel model)
        {

            foreach (var element in GetAllPerProductId(model.ProductId))
            {
                if (model.MainPicture)
                { element.MainPicture = false; }
                else
                { break; }
            }

            Image picture = new Image
            {
            ImageId= model.ImageId,
            ProductId = model.ProductId,
            FileName = model.FileName,
            Picture = new byte [model.Image.ContentLength],
            ImageMineType = model.Image.ContentType,
            MainPicture = model.MainPicture
        };
            
            using (MemoryStream memStream = new MemoryStream(model.Image.ContentLength))
            {
                // model.Image.InputStream.Read(picture.Picture,0, model.Image.ContentLength);
                model.Image.InputStream.CopyTo(memStream, model.Image.ContentLength);
                picture.Picture = memStream.ToArray();
            }
            using (var context = new WebShopMVCContext())
            {
                 context.Images.Add(picture);
                 context.SaveChanges();
            }
        }
        public IEnumerable<PartImageViewModel> GetAllPerProductId(int id)
        {
            var list = new List<PartImageViewModel>();
            using (var context = new WebShopMVCContext())
            {
                list = context.Images.Select(m => new PartImageViewModel
                {
                    ImageId = m.ImageId,
                    ProductId = m.ProductId,
                    MainPicture = m.MainPicture,
                    FileName = m.FileName
                }).Where(m => m.ProductId==id).ToList();
            }
            return list;
        }
        public IEnumerable<PartImageViewModel> GetAll()
        {
            var list = new List<PartImageViewModel>();
            using (var context = new WebShopMVCContext())
            {
                list = context.Images.Select(m => new PartImageViewModel
                {
                    ImageId = m.ImageId,
                    ProductId = m.ProductId,
                    MainPicture= m.MainPicture,
                    FileName = m.FileName
                }).ToList();
            }
            return list;
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