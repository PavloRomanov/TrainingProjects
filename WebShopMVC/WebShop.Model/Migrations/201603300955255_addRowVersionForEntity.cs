namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRowVersionForEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "RowVersion", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Clients", "RowVersion", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Products", "RowVersion", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Subcategories", "RowVersion", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subcategories", "RowVersion");
            DropColumn("dbo.Products", "RowVersion");
            DropColumn("dbo.Clients", "RowVersion");
            DropColumn("dbo.Categories", "RowVersion");
        }
    }
}
