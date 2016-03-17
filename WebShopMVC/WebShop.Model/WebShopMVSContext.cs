using System;
using System.Data.Entity;
using WebShop.Model.Entities;

namespace WebShop.Model
{
    public class WebShopMVCContext : DbContext
    {
        public WebShopMVCContext()
        : base("name=WebShopDB")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
    }
}
