using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model.ViewModel;

namespace WebShop.Service.Contract
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel GetModelById(int id);
        void Create(CategoryViewModel model);
        void Update(CategoryViewModel model);
        void Delete(int id);
    }
}
