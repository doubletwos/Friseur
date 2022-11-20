namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221103 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "ClientType_ClientTypeId", "dbo.ClientTypes");
            DropIndex("dbo.Clients", new[] { "ClientType_ClientTypeId" });
            DropColumn("dbo.Clients", "ClientType_ClientTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "ClientType_ClientTypeId", c => c.Int());
            CreateIndex("dbo.Clients", "ClientType_ClientTypeId");
            AddForeignKey("dbo.Clients", "ClientType_ClientTypeId", "dbo.ClientTypes", "ClientTypeId");
        }
    }
}
