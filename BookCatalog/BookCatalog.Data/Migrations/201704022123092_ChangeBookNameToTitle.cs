namespace BookCatalog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBookNameToTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Title", c => c.String());
            DropColumn("dbo.Books", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Name", c => c.String());
            DropColumn("dbo.Books", "Title");
        }
    }
}
