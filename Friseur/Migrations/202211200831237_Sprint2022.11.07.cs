namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221107 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client_User", "AppUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client_User", "AppUserId");
        }
    }
}
