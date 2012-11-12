namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_dependencies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropIndex("dbo.Logins", new[] { "User_Id" });
            DropColumn("dbo.Logins", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "User_Id", c => c.Int());
            CreateIndex("dbo.Logins", "User_Id");
            AddForeignKey("dbo.Logins", "User_Id", "dbo.Users", "Id");
        }
    }
}
