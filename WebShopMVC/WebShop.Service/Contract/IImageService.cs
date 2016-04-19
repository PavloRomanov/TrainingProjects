using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model.ViewModel;

namespace WebShop.Service.Contract
{
   public interface IImageService
    {
        IEnumerable<ImageViewModel> GetAll();
        ImageViewModel GetModelById(int id);
        
        void Create(ImageViewModel model);
        void Update(ImageViewModel model);
        void Delete(int id);
    }
}
