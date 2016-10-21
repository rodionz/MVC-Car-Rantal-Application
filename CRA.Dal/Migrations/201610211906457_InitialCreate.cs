namespace CRA.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branch_Details",
                c => new
                    {
                        BranchID = c.Int(nullable: false, identity: true),
                        BranchName = c.String(maxLength: 15),
                        City = c.String(maxLength: 15),
                        District = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.BranchID);
            
            CreateTable(
                "dbo.Car_Details",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        Mileage = c.Double(nullable: false),
                        Picture = c.Binary(storeType: "image"),
                        ProperState = c.Boolean(nullable: false),
                        CarNumber = c.String(maxLength: 15),
                        BranchID = c.Int(nullable: false),
                        ModelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Branch_Details", t => t.BranchID, cascadeDelete: true)
                .ForeignKey("dbo.Model_Details", t => t.ModelID, cascadeDelete: true)
                .Index(t => t.BranchID)
                .Index(t => t.ModelID);
            
            CreateTable(
                "dbo.Model_Details",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(maxLength: 30),
                        Model = c.String(maxLength: 30),
                        DailyPrice = c.Decimal(nullable: false, storeType: "money"),
                        LateReturnFine = c.Decimal(nullable: false, storeType: "money"),
                        gear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelID);
            
            CreateTable(
                "dbo.Client_Details",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        BirthData = c.DateTime(),
                        gender = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.Deal_Details",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(),
                        SupposedReturn = c.DateTime(),
                        RealReturn = c.DateTime(),
                        ClientID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car_Details", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.Client_Details", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deal_Details", "ClientID", "dbo.Client_Details");
            DropForeignKey("dbo.Deal_Details", "CarID", "dbo.Car_Details");
            DropForeignKey("dbo.Car_Details", "ModelID", "dbo.Model_Details");
            DropForeignKey("dbo.Car_Details", "BranchID", "dbo.Branch_Details");
            DropIndex("dbo.Deal_Details", new[] { "CarID" });
            DropIndex("dbo.Deal_Details", new[] { "ClientID" });
            DropIndex("dbo.Car_Details", new[] { "ModelID" });
            DropIndex("dbo.Car_Details", new[] { "BranchID" });
            DropTable("dbo.Deal_Details");
            DropTable("dbo.Client_Details");
            DropTable("dbo.Model_Details");
            DropTable("dbo.Car_Details");
            DropTable("dbo.Branch_Details");
        }
    }
}
