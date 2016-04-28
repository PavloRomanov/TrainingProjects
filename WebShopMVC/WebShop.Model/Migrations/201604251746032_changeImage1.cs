namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeImage1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "FileName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "FileName");
        }
    }
}
