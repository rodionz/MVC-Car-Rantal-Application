namespace CarRental.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "ManufacturerId", c => c.Int());
            CreateIndex("dbo.Models", "ManufacturerId");
            AddForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Models", new[] { "ManufacturerId" });
            DropColumn("dbo.Models", "ManufacturerId");
        }
    }
}
