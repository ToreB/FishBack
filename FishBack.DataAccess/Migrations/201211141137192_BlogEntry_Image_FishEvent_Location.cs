namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogEntry_Image_FishEvent_Location : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FishEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Title = c.String(),
                        Comment = c.String(),
                        User_Id = c.Int(),
                        Location_Id = c.Int(),
                        BlogEntry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.BlogEntries", t => t.BlogEntry_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.BlogEntry_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MAMSL = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Title = c.String(),
                        FileName = c.String(),
                        OriginalFileName = c.String(),
                        User_Id = c.Int(),
                        Location_Id = c.Int(),
                        FishEvent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.FishEvents", t => t.FishEvent_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.FishEvent_Id);
            
            CreateTable(
                "dbo.BlogEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        EditDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BlogEntries", new[] { "User_Id" });
            DropIndex("dbo.Images", new[] { "FishEvent_Id" });
            DropIndex("dbo.Images", new[] { "Location_Id" });
            DropIndex("dbo.Images", new[] { "User_Id" });
            DropIndex("dbo.FishEvents", new[] { "BlogEntry_Id" });
            DropIndex("dbo.FishEvents", new[] { "Location_Id" });
            DropIndex("dbo.FishEvents", new[] { "User_Id" });
            DropForeignKey("dbo.BlogEntries", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Images", "FishEvent_Id", "dbo.FishEvents");
            DropForeignKey("dbo.Images", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Images", "User_Id", "dbo.Users");
            DropForeignKey("dbo.FishEvents", "BlogEntry_Id", "dbo.BlogEntries");
            DropForeignKey("dbo.FishEvents", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.FishEvents", "User_Id", "dbo.Users");
            DropTable("dbo.BlogEntries");
            DropTable("dbo.Images");
            DropTable("dbo.Locations");
            DropTable("dbo.FishEvents");
        }
    }
}
