namespace CarRental.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deals", "CarID", "dbo.Cars");
            DropForeignKey("dbo.Deals", "UserId", "dbo.Users");
            DropIndex("dbo.Deals", new[] { "UserId" });
            DropIndex("dbo.Deals", new[] { "CarID" });
            AlterColumn("dbo.Models", "NameofModel", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Manufacturers", "Manufacturer", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Deals", "Start", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Deals", "SupposedReturn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Deals", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Deals", "CarID", c => c.Int(nullable: false));
            CreateIndex("dbo.Deals", "UserId");
            CreateIndex("dbo.Deals", "CarID");
            AddForeignKey("dbo.Deals", "CarID", "dbo.Cars", "CarID", cascadeDelete: true);
            AddForeignKey("dbo.Deals", "UserId", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deals", "UserId", "dbo.Users");
            DropForeignKey("dbo.Deals", "CarID", "dbo.Cars");
            DropIndex("dbo.Deals", new[] { "CarID" });
            DropIndex("dbo.Deals", new[] { "UserId" });
            AlterColumn("dbo.Deals", "CarID", c => c.Int());
            AlterColumn("dbo.Deals", "UserId", c => c.Int());
            AlterColumn("dbo.Deals", "SupposedReturn", c => c.DateTime());
            AlterColumn("dbo.Deals", "Start", c => c.DateTime());
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Manufacturers", "Manufacturer", c => c.String());
            AlterColumn("dbo.Models", "NameofModel", c => c.String(maxLength: 30));
            CreateIndex("dbo.Deals", "CarID");
            CreateIndex("dbo.Deals", "UserId");
            AddForeignKey("dbo.Deals", "UserId", "dbo.Users", "ID");
            AddForeignKey("dbo.Deals", "CarID", "dbo.Cars", "CarID");
        }
    }
}
