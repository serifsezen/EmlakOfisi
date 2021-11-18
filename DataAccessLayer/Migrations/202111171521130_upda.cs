namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 30),
                        AdminPassword = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        AgentUserName = c.String(maxLength: 30),
                        NameOfTheFirm = c.String(maxLength: 30),
                        AgentPassword = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.Residences",
                c => new
                    {
                        ResidenceId = c.Int(nullable: false, identity: true),
                        NumberOfRooms = c.Int(nullable: false),
                        AgeOfResidence = c.Int(nullable: false),
                        SquareMeter = c.Int(nullable: false),
                        TypeOfResidence = c.String(maxLength: 20),
                        AgentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResidenceId)
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .Index(t => t.AgentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Residences", "AgentId", "dbo.Agents");
            DropIndex("dbo.Residences", new[] { "AgentId" });
            DropTable("dbo.Residences");
            DropTable("dbo.Agents");
            DropTable("dbo.Admins");
        }
    }
}
