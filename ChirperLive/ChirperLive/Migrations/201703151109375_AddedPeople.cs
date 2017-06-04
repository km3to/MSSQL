namespace ChirperLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPeople : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PLaceOfBirthId = c.Int(),
                        CurrentResidenceId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.CurrentResidenceId)
                .ForeignKey("dbo.Towns", t => t.PLaceOfBirthId)
                .Index(t => t.PLaceOfBirthId)
                .Index(t => t.CurrentResidenceId);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People1", "PLaceOfBirthId", "dbo.Towns");
            DropForeignKey("dbo.People1", "CurrentResidenceId", "dbo.Towns");
            DropIndex("dbo.People1", new[] { "CurrentResidenceId" });
            DropIndex("dbo.People1", new[] { "PLaceOfBirthId" });
            DropTable("dbo.Towns");
            DropTable("dbo.People1");
        }
    }
}
