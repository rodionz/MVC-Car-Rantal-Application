namespace CarRental.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deals", "UserId", c => c.Int());
            CreateIndex("dbo.Deals", "UserId");
            AddForeignKey("dbo.Deals", "UserId", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deals", "UserId", "dbo.Users");
            DropIndex("dbo.Deals", new[] { "UserId" });
            DropColumn("dbo.Deals", "UserId");
        }
    }
}
