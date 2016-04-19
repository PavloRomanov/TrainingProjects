namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _addImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 30),
                        MainPicture = c.Boolean(nullable: false),
                        RowVersion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropIndex("dbo.Images", new[] { "ProductId" });
            DropTable("dbo.Images");
        }
    }
}
