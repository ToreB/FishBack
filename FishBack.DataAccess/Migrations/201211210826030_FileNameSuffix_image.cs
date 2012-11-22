namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileNameSuffix_image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "FileNameSuffix", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "FileNameSuffix");
        }
    }
}
