namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixed_relationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Images", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Images", new[] { "User_Id" });
            DropIndex("dbo.Images", new[] { "Location_Id" });
            DropColumn("dbo.Images", "User_Id");
            DropColumn("dbo.Images", "Location_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Location_Id", c => c.Int());
            AddColumn("dbo.Images", "User_Id", c => c.Int());
            CreateIndex("dbo.Images", "Location_Id");
            CreateIndex("dbo.Images", "User_Id");
            AddForeignKey("dbo.Images", "Location_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.Images", "User_Id", "dbo.Users", "Id");
        }
    }
}
