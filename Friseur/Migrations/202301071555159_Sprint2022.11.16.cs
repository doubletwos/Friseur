namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221116 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Client_User", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client_User", "LastName", c => c.String());
        }
    }
}
