namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _changeProduts : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Products", "SubcategoryId");
            AddForeignKey("dbo.Products", "SubcategoryId", "dbo.Subcategories", "SubcategoryId", cascadeDelete: true);
            DropColumn("dbo.Products", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "SubcategoryId", "dbo.Subcategories");
            DropIndex("dbo.Products", new[] { "SubcategoryId" });
        }
    }
}
