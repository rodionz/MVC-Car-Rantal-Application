namespace CarRental.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "Manufacturer_ID", "dbo.Manufacturers");
            DropIndex("dbo.Models", new[] { "Manufacturer_ID" });
            DropColumn("dbo.Models", "Manufacturer_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "Manufacturer_ID", c => c.Int());
            CreateIndex("dbo.Models", "Manufacturer_ID");
            AddForeignKey("dbo.Models", "Manufacturer_ID", "dbo.Manufacturers", "ID");
        }
    }
}
