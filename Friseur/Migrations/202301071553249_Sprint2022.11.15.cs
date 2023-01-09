namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221115 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client_User", "Name", c => c.String());
            DropColumn("dbo.Client_User", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client_User", "FirstName", c => c.String());
            DropColumn("dbo.Client_User", "Name");
        }
    }
}
