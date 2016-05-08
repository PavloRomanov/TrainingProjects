namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteClientMigration : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Clients");
        }
        
        public override void Down()
        {
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
                        RowVersion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ClientId);
            
        }
    }
}
