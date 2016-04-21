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
                CategoryId = model.CategoryId,
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
                list = context.Subcategories.Include("Categories").Select(m => new SubcategoryViewModel
                {
                    CategoryId = m.CategoryId,
                    SubcategoryId = m.SubcategoryId,
                    SubcategoryName = m.SubcategoryName,
                    CategoryName = m.Category.CategoryName
                }).ToList();
            }
            return list;
        }
       
          public CompositeSubcategoryViewModel GetNewSubcategoryViewModelWithCategories()
          {
              CompositeSubcategoryViewModel model = new CompositeSubcategoryViewModel();

              using (var context = new WebShopMVCContext())
              {
                  model.Categories = context.Categories.Select(c => new CategoryViewModel
                  { CategoryName = c.CategoryName, CategoryId = c.CategoryId }).ToList();

              }
              return model;
         
    } 

        public CompositeSubcategoryViewModel GetModelById(int id)
        {
            CompositeSubcategoryViewModel model;

            using (var context = new WebShopMVCContext())
            {
                var subcategory = context.Subcategories.Find(id);
                model = new CompositeSubcategoryViewModel
                {
                    CategoryId = subcategory.CategoryId,
                    SubcategoryId = subcategory.SubcategoryId,
                    SubcategoryName = subcategory.SubcategoryName,
                    Categories = context.Categories.Select(c => new CategoryViewModel
                        { CategoryName = c.CategoryName, CategoryId = c.CategoryId }).ToList()
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
                subcategory.CategoryId = model.CategoryId;
                context.SaveChanges();
            }
        }
    }
}
