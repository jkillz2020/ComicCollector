namespace ComicCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComicCollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComicCollections", "IssueNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ComicCollections", "Image", c => c.String());
            DropColumn("dbo.ComicCollections", "Password");
            DropColumn("dbo.ComicCollections", "Issue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComicCollections", "Issue", c => c.Int(nullable: false));
            AddColumn("dbo.ComicCollections", "Password", c => c.String());
            DropColumn("dbo.ComicCollections", "Image");
            DropColumn("dbo.ComicCollections", "IssueNumber");
        }
    }
}
