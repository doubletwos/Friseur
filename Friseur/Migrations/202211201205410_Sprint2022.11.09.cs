namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221109 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Client_User", "ClientId");
            AddForeignKey("dbo.Client_User", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client_User", "ClientId", "dbo.Clients");
            DropIndex("dbo.Client_User", new[] { "ClientId" });
        }
    }
}
