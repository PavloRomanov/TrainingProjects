namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(maxLength: 16),
                        Email = c.String(maxLength: 30),
                        Login = c.String(maxLength: 10),
                        Password = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 30),
                        CategoryId = c.Int(nullable: false),
                        SubcategoryId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Int(nullable: false),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        SubcategoryId = c.Int(nullable: false, identity: true),
                        SubcategoryName = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubcategoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subcategories");
            DropTable("dbo.Products");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
        }
    }
}
