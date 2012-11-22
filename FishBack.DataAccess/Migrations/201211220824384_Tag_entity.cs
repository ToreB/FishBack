namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tag_entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagBlogEntries",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        BlogEntry_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.BlogEntry_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.BlogEntries", t => t.BlogEntry_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.BlogEntry_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TagBlogEntries", new[] { "BlogEntry_Id" });
            DropIndex("dbo.TagBlogEntries", new[] { "Tag_Id" });
            DropForeignKey("dbo.TagBlogEntries", "BlogEntry_Id", "dbo.BlogEntries");
            DropForeignKey("dbo.TagBlogEntries", "Tag_Id", "dbo.Tags");
            DropTable("dbo.TagBlogEntries");
            DropTable("dbo.Tags");
        }
    }
}
