namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_some_user_properties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "User_Id", c => c.Int());
            AddForeignKey("dbo.Logins", "User_Id", "dbo.Users", "Id");
            CreateIndex("dbo.Logins", "User_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Logins", new[] { "User_Id" });
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropColumn("dbo.Logins", "User_Id");
        }
    }
}
