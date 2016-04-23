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
    public class ProductService : IProductService
    {
        public void Create(ProductViewModel model)
        {
            Product product = new Product
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                SubcategoryId = model.SubcategoryId,
                Price = model.Price,
                Discount = model.Discount,
                Description = model.Description
            };
            using (var context = new WebShopMVCContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var list = new List<ProductViewModel>();
            using (var context = new WebShopMVCContext())
            {
                list = context.Products.Select(m => new ProductViewModel
                {
                    ProductId = m.ProductId,
                    ProductName = m.ProductName,
                    SubcategoryId = m.SubcategoryId,
                    Price = m.Price,
                    Discount = m.Discount,
                    Description = m.Description
                }).ToList();
            }
            return list;
        }
        public IEnumerable<ProductViewModel> GetProductsOfSubcategory(int Id)
        {
            var list = new List<ProductViewModel>();
            using (var context = new WebShopMVCContext())
            {
                list = context.Products.Select(m => new ProductViewModel
                {
                    ProductId = m.ProductId,
                    ProductName = m.ProductName,
                    SubcategoryId = m.SubcategoryId,
                    Price = m.Price,
                    Discount = m.Discount,
                    Description = m.Description
                }).Where(m => m.ProductId == Id).ToList();
           
            }
            return list;
        }
        public ProductViewModel GetNewProductViewModelWithSubcategory()
        {
            ProductViewModel model = new ProductViewModel();

            using (var context = new WebShopMVCContext())
            {
                model.Subcategories = context.Subcategories.Select(c => new PartViewSubcategoriesForProduct
                {
                    SubcategoryName = c.SubcategoryName,
                    SubcategoryId = c.SubcategoryId
                }).ToList();

            }
            return model;
        }
       
        public ProductViewModel GetModelById(int id)
        {
            ProductViewModel model;

            using (var context = new WebShopMVCContext())
            {
                var product = context.Products.Find(id);
                model = new ProductViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    SubcategoryId = product.SubcategoryId,
                    Price = product.Price,
                    Discount = product.Discount,
                    Description = product.Description,
                    Subcategories = context.Subcategories.Select(c => new PartViewSubcategoriesForProduct
                    {
                        SubcategoryName = c.SubcategoryName,
                        SubcategoryId = c.SubcategoryId
                    }).ToList()
                };
            }
            return model;
        }

        public void Update(ProductViewModel model)
        {
            using (var context = new WebShopMVCContext())
            {
            var product = context.Products.Find(model.ProductId);
            product.ProductName = model.ProductName;
            product.SubcategoryId = model.SubcategoryId;
            product.Price = model.Price;
            product.Discount = model.Discount;
            product.Description = model.Description;
            context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new WebShopMVCContext())
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
