namespace CitySpeaks_samle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _020420171 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Page = c.String(nullable: false),
                        BigImageData = c.Binary(),
                        BigImageMimeType = c.String(),
                        IsShow = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomPages");
        }
    }
}
