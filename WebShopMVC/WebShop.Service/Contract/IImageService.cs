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
        void Create(MainImageViewModel model);
        IEnumerable<PartImageViewModel> GetAll();
        void Delete(int id);
    }
}
