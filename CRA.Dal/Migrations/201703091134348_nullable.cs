namespace CarRental.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Models", new[] { "ManufacturerId" });
            AlterColumn("dbo.Models", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Models", "ManufacturerId");
            AddForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Models", new[] { "ManufacturerId" });
            AlterColumn("dbo.Models", "ManufacturerId", c => c.Int());
            CreateIndex("dbo.Models", "ManufacturerId");
            AddForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers", "ID");
        }
    }
}
