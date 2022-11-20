namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221106 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client_User",
                c => new
                    {
                        Client_UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        ClientId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        LastLogOnDate = c.DateTime(),
                        LogOnCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Client_UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Client_User");
        }
    }
}
