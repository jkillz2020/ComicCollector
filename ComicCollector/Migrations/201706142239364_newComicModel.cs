namespace ComicCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newComicModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ComicCollections", newName: "Comics");
            AddColumn("dbo.Comics", "Uid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comics", "Uid");
            RenameTable(name: "dbo.Comics", newName: "ComicCollections");
        }
    }
}
