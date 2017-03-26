namespace CitySpeaks_samle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _230320171 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Programs", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Programs", "ShortDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Programs", "FullDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Programs", "FullDescription", c => c.String());
            AlterColumn("dbo.Programs", "ShortDescription", c => c.String());
            AlterColumn("dbo.Programs", "Name", c => c.String());
        }
    }
}
