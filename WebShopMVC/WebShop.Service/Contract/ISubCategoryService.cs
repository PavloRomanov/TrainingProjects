using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model.ViewModel;

namespace WebShop.Service.Contract
{
    public interface ISubcategoryService
    {
        IEnumerable<SubcategoryViewModel> GetAll();
        CompositeSubcategoryViewModel GetModelById(int id);
        CompositeSubcategoryViewModel GetNewSubcategoryViewModelWithCategories();
        void Create(SubcategoryViewModel model);
        void Update(SubcategoryViewModel model);
        void Delete(int id);
    }
}
