namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSubcategoryMigration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Subcategories", "CategoryId");
            AddForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
        }
    }
}
