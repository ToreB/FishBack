namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_FishEvent_relationship_from_BlogEntry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FishEvents", "BlogEntry_Id", "dbo.BlogEntries");
            DropIndex("dbo.FishEvents", new[] { "BlogEntry_Id" });
            DropColumn("dbo.FishEvents", "BlogEntry_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FishEvents", "BlogEntry_Id", c => c.Int());
            CreateIndex("dbo.FishEvents", "BlogEntry_Id");
            AddForeignKey("dbo.FishEvents", "BlogEntry_Id", "dbo.BlogEntries", "Id");
        }
    }
}
