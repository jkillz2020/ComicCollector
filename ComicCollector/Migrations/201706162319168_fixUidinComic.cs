namespace ComicCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixUidinComic : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comics", "Uid", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comics", "Uid", c => c.Int(nullable: false));
        }
    }
}
