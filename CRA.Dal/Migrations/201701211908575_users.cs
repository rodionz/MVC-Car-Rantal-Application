namespace CarRental.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;

    public partial class users : DbMigration
    {
        public override void Up()
        {

            RenameColumn("dbo.Users", "UserID", "ID");

        }
        
        public override void Down()
        {
            RenameColumn("dbo.Users", "ID", "UserID");
        }
    }
}
