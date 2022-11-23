namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ClientId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ClientId");
        }
    }
}
