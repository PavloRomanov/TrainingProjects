using System;
using System.Data.Entity;
using System.Linq;
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
        public DbSet<Image> Images { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            var selectedEntityList = ChangeTracker.Entries()
                                    .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entity in selectedEntityList)
            {
                ((Base)entity.Entity).RowVersion = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
