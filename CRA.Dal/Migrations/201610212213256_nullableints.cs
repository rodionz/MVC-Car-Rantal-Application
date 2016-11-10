namespace CarRent.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableints : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Car_Details", "BranchID", "dbo.Branch_Details");
            DropForeignKey("dbo.Car_Details", "ModelID", "dbo.Model_Details");
            DropForeignKey("dbo.Deal_Details", "CarID", "dbo.Car_Details");
            DropForeignKey("dbo.Deal_Details", "ClientID", "dbo.Client_Details");
            DropIndex("dbo.Car_Details", new[] { "BranchID" });
            DropIndex("dbo.Car_Details", new[] { "ModelID" });
            DropIndex("dbo.Deal_Details", new[] { "ClientID" });
            DropIndex("dbo.Deal_Details", new[] { "CarID" });
            AlterColumn("dbo.Car_Details", "Mileage", c => c.Double());
            AlterColumn("dbo.Car_Details", "BranchID", c => c.Int());
            AlterColumn("dbo.Car_Details", "ModelID", c => c.Int());
            AlterColumn("dbo.Model_Details", "gear", c => c.Int());
            AlterColumn("dbo.Deal_Details", "ClientID", c => c.Int());
            AlterColumn("dbo.Deal_Details", "CarID", c => c.Int());
            CreateIndex("dbo.Car_Details", "BranchID");
            CreateIndex("dbo.Car_Details", "ModelID");
            CreateIndex("dbo.Deal_Details", "ClientID");
            CreateIndex("dbo.Deal_Details", "CarID");
            AddForeignKey("dbo.Car_Details", "BranchID", "dbo.Branch_Details", "BranchID");
            AddForeignKey("dbo.Car_Details", "ModelID", "dbo.Model_Details", "ModelID");
            AddForeignKey("dbo.Deal_Details", "CarID", "dbo.Car_Details", "CarID");
            AddForeignKey("dbo.Deal_Details", "ClientID", "dbo.Client_Details", "ClientID");
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
            AlterColumn("dbo.Deal_Details", "CarID", c => c.Int(nullable: false));
            AlterColumn("dbo.Deal_Details", "ClientID", c => c.Int(nullable: false));
            AlterColumn("dbo.Model_Details", "gear", c => c.Int(nullable: false));
            AlterColumn("dbo.Car_Details", "ModelID", c => c.Int(nullable: false));
            AlterColumn("dbo.Car_Details", "BranchID", c => c.Int(nullable: false));
            AlterColumn("dbo.Car_Details", "Mileage", c => c.Double(nullable: false));
            CreateIndex("dbo.Deal_Details", "CarID");
            CreateIndex("dbo.Deal_Details", "ClientID");
            CreateIndex("dbo.Car_Details", "ModelID");
            CreateIndex("dbo.Car_Details", "BranchID");
            AddForeignKey("dbo.Deal_Details", "ClientID", "dbo.Client_Details", "ClientID", cascadeDelete: true);
            AddForeignKey("dbo.Deal_Details", "CarID", "dbo.Car_Details", "CarID", cascadeDelete: true);
            AddForeignKey("dbo.Car_Details", "ModelID", "dbo.Model_Details", "ModelID", cascadeDelete: true);
            AddForeignKey("dbo.Car_Details", "BranchID", "dbo.Branch_Details", "BranchID", cascadeDelete: true);
        }
    }
}
