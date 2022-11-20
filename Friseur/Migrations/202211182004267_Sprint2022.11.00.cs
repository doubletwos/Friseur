namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientClientTypes",
                c => new
                    {
                        ClientClientTypeId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ClientTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientClientTypeId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.ClientTypes", t => t.ClientTypeId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ClientTypeId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Client_Address = c.String(),
                        Created_By = c.String(),
                        CreationDate = c.DateTime(),
                        ClientType_ClientTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.ClientTypes", t => t.ClientType_ClientTypeId)
                .Index(t => t.ClientType_ClientTypeId);
            
            CreateTable(
                "dbo.ClientTypes",
                c => new
                    {
                        ClientTypeId = c.Int(nullable: false, identity: true),
                        ClientTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClientTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientClientTypes", "ClientTypeId", "dbo.ClientTypes");
            DropForeignKey("dbo.ClientClientTypes", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ClientType_ClientTypeId", "dbo.ClientTypes");
            DropIndex("dbo.Clients", new[] { "ClientType_ClientTypeId" });
            DropIndex("dbo.ClientClientTypes", new[] { "ClientTypeId" });
            DropIndex("dbo.ClientClientTypes", new[] { "ClientId" });
            DropTable("dbo.ClientTypes");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientClientTypes");
        }
    }
}
