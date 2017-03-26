namespace CitySpeaks_samle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _230320173 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProgramCategories", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProgramCategories", "Name", c => c.String());
        }
    }
}
