namespace CarRent.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Branch_Details", newName: "Branches");
            RenameTable(name: "dbo.Car_Details", newName: "Cars");
            RenameTable(name: "dbo.Model_Details", newName: "Models");
            RenameTable(name: "dbo.Client_Details", newName: "Users");
            RenameTable(name: "dbo.Deal_Details", newName: "Deals");
            AddColumn("dbo.Models", "NameofModel", c => c.String(maxLength: 30));
            AlterColumn("dbo.Models", "gear", c => c.Int(nullable: false));
            DropColumn("dbo.Models", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "Model", c => c.String(maxLength: 30));
            AlterColumn("dbo.Models", "gear", c => c.Int());
            DropColumn("dbo.Models", "NameofModel");
            RenameTable(name: "dbo.Deals", newName: "Deal_Details");
            RenameTable(name: "dbo.Users", newName: "Client_Details");
            RenameTable(name: "dbo.Models", newName: "Model_Details");
            RenameTable(name: "dbo.Cars", newName: "Car_Details");
            RenameTable(name: "dbo.Branches", newName: "Branch_Details");
        }
    }
}
