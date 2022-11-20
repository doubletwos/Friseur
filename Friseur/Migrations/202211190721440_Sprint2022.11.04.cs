namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221104 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "ClientTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "ClientTypeId");
            AddForeignKey("dbo.Clients", "ClientTypeId", "dbo.ClientTypes", "ClientTypeId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "ClientTypeId", "dbo.ClientTypes");
            DropIndex("dbo.Clients", new[] { "ClientTypeId" });
            DropColumn("dbo.Clients", "ClientTypeId");
        }
    }
}
