namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        RowVersion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.ClientId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Carts", "ClientId", "dbo.Clients");
            DropIndex("dbo.Carts", new[] { "Product_ProductId" });
            DropIndex("dbo.Carts", new[] { "ClientId" });
            DropTable("dbo.Carts");
        }
    }
}
