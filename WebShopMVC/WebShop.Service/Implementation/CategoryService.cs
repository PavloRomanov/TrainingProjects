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
    public class CategoryService : ICategoryService
    {

        public void Create(CategoryViewModel model)
        {

            Category category = new Category
            {
                CategoryName = model.CategoryName
            };

            using (var context = new WebShopMVCContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }


        public void Delete(int id)
        {
            using (var context = new WebShopMVCContext())
            {

                var category = context.Categories.Find(id);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var list = new List<CategoryViewModel>();
            using (var context = new WebShopMVCContext())
            {
                list = context.Categories.Select(m => new CategoryViewModel
                {
                    CategoryName = m.CategoryName
                }).ToList();
            }
            return list;
        }

        public CategoryViewModel GetModelById(int id)
        {
            CategoryViewModel model;

            using (var context = new WebShopMVCContext())
            {
                var category = context.Categories.Find(id);
                model = new CategoryViewModel
                {
                    CategoryName = category.CategoryName
                };

            }
            return model;

        }

        public void Update(CategoryViewModel model)
        {
            using (var context = new WebShopMVCContext())
            {
                var category = context.Categories.Find(model.CategoryId);
                category.CategoryName = model.CategoryName;
                context.SaveChangesAsync();
            }
        }
    }
}
