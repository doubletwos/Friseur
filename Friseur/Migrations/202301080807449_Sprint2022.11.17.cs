namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221117 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client_User", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client_User", "DateAdded");
        }
    }
}
