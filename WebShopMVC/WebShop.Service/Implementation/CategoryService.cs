using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    CategoryId = m.CategoryId,
                    CategoryName = m.CategoryName
                }).ToList();
            }
            return list;
        }

        public IEnumerable<CompositeCategoryViewModel> GetAllWithSubcategory()
        {
            using (var context = new WebShopMVCContext())
            {
                //context.Database.Log = message => Trace.Write(message);
                return context.Categories.Select(c => new CompositeCategoryViewModel
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Subcategories = context.Subcategories.Where(s => s.CategoryId == c.CategoryId).Select(s => new SubcategoryViewModel
                    {
                        SubcategoryId = s.SubcategoryId,
                        SubcategoryName = s.SubcategoryName
                    })
                }).ToList();
            }
        }

        public CategoryViewModel GetModelById(int id)
        {
            CategoryViewModel model;

            using (var context = new WebShopMVCContext())
            {
                var category = context.Categories.Find(id);
                model = new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
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
                category.RowVersion = new DateTime();
                context.SaveChanges();
            }
        }
    }
}
