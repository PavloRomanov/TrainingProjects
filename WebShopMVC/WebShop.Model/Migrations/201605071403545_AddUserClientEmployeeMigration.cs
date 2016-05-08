namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserClientEmployeeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 10),
                        Password = c.String(maxLength: 10),
                        Email = c.String(maxLength: 30),
                        IsEmployee = c.Boolean(nullable: false),
                        RowVersion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Phone = c.String(maxLength: 16),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Address = c.String(maxLength: 256),
                        Phone = c.String(maxLength: 16),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "UserId", "dbo.Users");
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.Clients", new[] { "UserId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
            DropTable("dbo.Users");
        }
    }
}
