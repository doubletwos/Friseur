namespace Friseur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprint20221108 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeId = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserTypeId);
            
            AddColumn("dbo.Client_User", "GenderId", c => c.Int(nullable: false));
            AddColumn("dbo.Client_User", "UserTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Client_User", "GenderId");
            CreateIndex("dbo.Client_User", "UserTypeId");
            AddForeignKey("dbo.Client_User", "GenderId", "dbo.Genders", "GenderId", cascadeDelete: true);
            AddForeignKey("dbo.Client_User", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client_User", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Client_User", "GenderId", "dbo.Genders");
            DropIndex("dbo.Client_User", new[] { "UserTypeId" });
            DropIndex("dbo.Client_User", new[] { "GenderId" });
            DropColumn("dbo.Client_User", "UserTypeId");
            DropColumn("dbo.Client_User", "GenderId");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Genders");
        }
    }
}
