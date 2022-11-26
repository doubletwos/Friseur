namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221113 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ClientId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ClientId", c => c.Int());
        }
    }
}
