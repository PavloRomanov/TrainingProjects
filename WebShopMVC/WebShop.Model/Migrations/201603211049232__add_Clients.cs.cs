
namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _add_Clients : DbMigration
    {
        public override void Up()
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
                })
                .PrimaryKey(t => t.ClientId);

        }

        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
