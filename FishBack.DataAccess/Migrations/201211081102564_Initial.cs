namespace FishBack.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        CountryCode = c.String(),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        ZipCode = c.String(),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Priority = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PasswordClearText = c.String(),
                        PasswordHash = c.String(),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginTime = c.DateTime(nullable: false),
                        LogoutTime = c.DateTime(nullable: false),
                        Ip = c.String(),
                        User_Id = c.Int(),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.Guid(nullable: false),
                        Begin = c.DateTime(nullable: false),
                        Expires = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        ClientId = c.Guid(nullable: false),
                        SoftwareVersion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        ClientInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientInfo_Id)
                .Index(t => t.ClientInfo_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClientLogins", new[] { "ClientInfo_Id" });
            DropIndex("dbo.Logins", new[] { "Session_Id" });
            DropIndex("dbo.Logins", new[] { "User_Id" });
            DropIndex("dbo.Passwords", new[] { "User_Id" });
            DropIndex("dbo.Emails", new[] { "User_Id" });
            DropIndex("dbo.Addresses", new[] { "User_Id" });
            DropIndex("dbo.Phones", new[] { "User_Id" });
            DropForeignKey("dbo.ClientLogins", "ClientInfo_Id", "dbo.Clients");
            DropForeignKey("dbo.Logins", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Passwords", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Emails", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Addresses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Phones", "User_Id", "dbo.Users");
            DropTable("dbo.ClientLogins");
            DropTable("dbo.Clients");
            DropTable("dbo.Sessions");
            DropTable("dbo.Logins");
            DropTable("dbo.Passwords");
            DropTable("dbo.Emails");
            DropTable("dbo.Addresses");
            DropTable("dbo.Phones");
            DropTable("dbo.Users");
        }
    }
}
