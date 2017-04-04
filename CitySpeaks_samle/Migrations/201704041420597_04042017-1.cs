namespace CitySpeaks_samle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _040420171 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "FullDescription", c => c.String());
            AddColumn("dbo.Workers", "BigImageData", c => c.Binary());
            AddColumn("dbo.Workers", "BigImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "BigImageMimeType");
            DropColumn("dbo.Workers", "BigImageData");
            DropColumn("dbo.Workers", "FullDescription");
        }
    }
}
