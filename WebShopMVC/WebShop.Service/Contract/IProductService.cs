using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model.ViewModel;

namespace WebShop.Service.Contract
{
   public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel GetModelById(int id);
        ProductViewModel GetNewProductViewModelWithSubcategory();
        void Create(ProductViewModel model);
        void Update(ProductViewModel model);
        void Delete(int id);
    }
}
