namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteIsEmployeeFromUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "IsEmployee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsEmployee", c => c.Boolean(nullable: false));
        }
    }
}
