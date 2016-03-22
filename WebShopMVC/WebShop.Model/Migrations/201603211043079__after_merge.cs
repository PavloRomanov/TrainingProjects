namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _after_merge : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
        }
    }
}
