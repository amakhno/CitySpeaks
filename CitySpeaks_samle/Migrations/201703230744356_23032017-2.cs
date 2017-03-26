namespace CitySpeaks_samle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _230320172 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.News", "ShortDescription", c => c.String(nullable: false));
            AlterColumn("dbo.News", "FullDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "FullDescription", c => c.String());
            AlterColumn("dbo.News", "ShortDescription", c => c.String());
            AlterColumn("dbo.News", "Name", c => c.String());
        }
    }
}
