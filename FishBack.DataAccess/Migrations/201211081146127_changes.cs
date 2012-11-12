namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientLogins", "ClientInfo_Id", "dbo.Clients");
            DropIndex("dbo.ClientLogins", new[] { "ClientInfo_Id" });
            DropTable("dbo.ClientLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClientLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        ClientInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ClientLogins", "ClientInfo_Id");
            AddForeignKey("dbo.ClientLogins", "ClientInfo_Id", "dbo.Clients", "Id");
        }
    }
}
