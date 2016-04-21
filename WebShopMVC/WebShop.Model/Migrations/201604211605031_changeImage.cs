namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageMineType", c => c.String());
            AlterColumn("dbo.Images", "Picture", c => c.Binary());
            DropColumn("dbo.Images", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "FileName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Images", "Picture", c => c.Binary(nullable: false));
            DropColumn("dbo.Images", "ImageMineType");
        }
    }
}
