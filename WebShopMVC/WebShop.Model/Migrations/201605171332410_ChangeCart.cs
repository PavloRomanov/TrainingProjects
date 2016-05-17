namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Carts", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ClientId" });
            DropIndex("dbo.Carts", new[] { "Product_ProductId" });
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        RowVersion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ProductId);
            
            DropTable("dbo.Carts");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.CartId);
            
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CartItems", "ClientId", "dbo.Clients");
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropIndex("dbo.CartItems", new[] { "ClientId" });
            DropTable("dbo.CartItems");
            CreateIndex("dbo.Carts", "Product_ProductId");
            CreateIndex("dbo.Carts", "ClientId");
            AddForeignKey("dbo.Carts", "Product_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.Carts", "ClientId", "dbo.Clients", "UserId");
        }
    }
}
