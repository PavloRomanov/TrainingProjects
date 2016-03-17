using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Model.Entities;


namespace Model
{
    public class WebShopMVCContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
    }
}
