namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes_in_Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Size", c => c.Long(nullable: false));
            AddColumn("dbo.Images", "Bytes", c => c.Binary());
            AddColumn("dbo.Images", "MIMEType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "MIMEType");
            DropColumn("dbo.Images", "Bytes");
            DropColumn("dbo.Images", "Size");
        }
    }
}
