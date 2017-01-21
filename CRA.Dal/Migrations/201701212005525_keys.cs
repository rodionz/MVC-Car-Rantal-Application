namespace CarRental.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keys : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRoles", newName: "RolesUsers");
            DropPrimaryKey("dbo.RolesUsers");
            AddPrimaryKey("dbo.RolesUsers", new[] { "Roles_RoleId", "User_ClientID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RolesUsers");
            AddPrimaryKey("dbo.RolesUsers", new[] { "User_ClientID", "Roles_RoleId" });
            RenameTable(name: "dbo.RolesUsers", newName: "UserRoles");
        }
    }
}
