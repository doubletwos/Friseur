namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221102 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "ClientType_ClientTypeId", "dbo.ClientTypes");
            DropIndex("dbo.Clients", new[] { "ClientType_ClientTypeId" });
            AlterColumn("dbo.Clients", "ClientType_ClientTypeId", c => c.Int());
            CreateIndex("dbo.Clients", "ClientType_ClientTypeId");
            AddForeignKey("dbo.Clients", "ClientType_ClientTypeId", "dbo.ClientTypes", "ClientTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "ClientType_ClientTypeId", "dbo.ClientTypes");
            DropIndex("dbo.Clients", new[] { "ClientType_ClientTypeId" });
            AlterColumn("dbo.Clients", "ClientType_ClientTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "ClientType_ClientTypeId");
            AddForeignKey("dbo.Clients", "ClientType_ClientTypeId", "dbo.ClientTypes", "ClientTypeId", cascadeDelete: true);
        }
    }
}
