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
    public class SubcategoryService : ISubcategoryService
    {

        public void Create(SubcategoryViewModel model)
        {

            Subcategory subcategory = new Subcategory
            {
                SubcategoryName = model.SubcategoryName
            };

            using (var context = new WebShopMVCContext())
            {
                context.Subcategories.Add(subcategory);
                context.SaveChanges();
            }
        }


        public void Delete(int id)
        {
            using (var context = new WebShopMVCContext())
            {

                var subcategory = context.Subcategories.Find(id);
                context.Subcategories.Remove(subcategory);
                context.SaveChanges();
            }
        }

        public IEnumerable<SubcategoryViewModel> GetAll()
        {
            var list = new List<SubcategoryViewModel>();
            using (var context = new WebShopMVCContext())
            {
                list = context.Subcategories.Select(m => new SubcategoryViewModel
                {
                    SubcategoryName = m.SubcategoryName
                }).ToList();
            }
            return list;
        }

        public SubcategoryViewModel GetModelById(int id)
        {
            SubcategoryViewModel model;

            using (var context = new WebShopMVCContext())
            {
                var subcategory = context.Subcategories.Find(id);
                model = new SubcategoryViewModel
                {
                    SubcategoryName = subcategory.SubcategoryName
                };

            }
            return model;

        }

        public void Update(SubcategoryViewModel model)
        {
            using (var context = new WebShopMVCContext())
            {
                var subcategory = context.Subcategories.Find(model.SubcategoryId);
                subcategory.SubcategoryName = model.SubcategoryName;
                context.SaveChangesAsync();
            }
        }
    }
}
