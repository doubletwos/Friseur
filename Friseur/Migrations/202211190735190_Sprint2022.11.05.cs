namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221105 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ClientTypes", "ClientTypeName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ClientTypes", "ClientTypeName", c => c.String(nullable: false));
        }
    }
}
