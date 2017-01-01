namespace CarRental.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initiall : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Branches",
            //    c => new
            //        {
            //            BranchID = c.Int(nullable: false, identity: true),
            //            BranchName = c.String(maxLength: 15),
            //            City = c.String(maxLength: 15),
            //            District = c.String(maxLength: 15),
            //            Location = c.Geography(),
            //        })
            //    .PrimaryKey(t => t.BranchID);
            
            //CreateTable(
            //    "dbo.Cars",
            //    c => new
            //        {
            //            CarID = c.Int(nullable: false, identity: true),
            //            Mileage = c.Double(),
            //            Picture = c.Binary(storeType: "image"),
            //            ProperState = c.Boolean(nullable: false),
            //            CarNumber = c.String(maxLength: 15),
            //            BranchID = c.Int(),
            //            ModelID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.CarID)
            //    .ForeignKey("dbo.Branches", t => t.BranchID)
            //    .ForeignKey("dbo.Models", t => t.ModelID)
            //    .Index(t => t.BranchID)
            //    .Index(t => t.ModelID);
            
            //CreateTable(
            //    "dbo.Models",
            //    c => new
            //        {
            //            ModelID = c.Int(nullable: false, identity: true),
            //            NameofModel = c.String(maxLength: 30),
            //            DailyPrice = c.Decimal(nullable: false, storeType: "money"),
            //            LateReturnFine = c.Decimal(nullable: false, storeType: "money"),
            //            gear = c.Int(nullable: false),
            //            Manufacturer_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ModelID)
            //    .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_ID)
            //    .Index(t => t.Manufacturer_ID);
            
            //CreateTable(
            //    "dbo.Manufacturers",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Manufacturer = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.Roles",
            //    c => new
            //        {
            //            RoleId = c.Int(nullable: false, identity: true),
            //            RoleName = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.RoleId);
            
            //CreateTable(
            //    "dbo.Users",
            //    c => new
            //        {
            //            UserID = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(nullable: false, maxLength: 15),
            //            LastName = c.String(nullable: false, maxLength: 15),
            //            UserName = c.String(maxLength: 15),
            //            BirthData = c.DateTime(),
            //            gender = c.Int(nullable: false),
            //            Email = c.String(nullable: false, maxLength: 30),
            //            Password = c.String(nullable: false, maxLength: 20),
            //        })
            //    .PrimaryKey(t => t.UserID);
            
            //CreateTable(
            //    "dbo.Deals",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Start = c.DateTime(),
            //            SupposedReturn = c.DateTime(),
            //            RealReturn = c.DateTime(),
            //            CarID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Cars", t => t.CarID)
            //    .Index(t => t.CarID);
            
            //CreateTable(
            //    "dbo.UserRoles",
            //    c => new
            //        {
            //            User_UserID = c.Int(nullable: false),
            //            Roles_RoleId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.User_UserID, t.Roles_RoleId })
            //    .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
            //    .ForeignKey("dbo.Roles", t => t.Roles_RoleId, cascadeDelete: true)
            //    .Index(t => t.User_UserID)
            //    .Index(t => t.Roles_RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deals", "CarID", "dbo.Cars");
            DropForeignKey("dbo.UserRoles", "Roles_RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Cars", "ModelID", "dbo.Models");
            DropForeignKey("dbo.Models", "Manufacturer_ID", "dbo.Manufacturers");
            DropForeignKey("dbo.Cars", "BranchID", "dbo.Branches");
            DropIndex("dbo.UserRoles", new[] { "Roles_RoleId" });
            DropIndex("dbo.UserRoles", new[] { "User_UserID" });
            DropIndex("dbo.Deals", new[] { "CarID" });
            DropIndex("dbo.Models", new[] { "Manufacturer_ID" });
            DropIndex("dbo.Cars", new[] { "ModelID" });
            DropIndex("dbo.Cars", new[] { "BranchID" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Deals");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Models");
            DropTable("dbo.Cars");
            DropTable("dbo.Branches");
        }
    }
}
