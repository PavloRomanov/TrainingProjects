namespace WebShop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IsDelete_and_IsBlocked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsBlocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsDelete");
            DropColumn("dbo.Employees", "IsBlocked");
        }
    }
}
