namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint202212 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ClientId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ClientId", c => c.Int(nullable: false));
        }
    }
}
