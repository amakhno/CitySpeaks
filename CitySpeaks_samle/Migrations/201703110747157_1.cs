namespace CitySpeaks_samle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgramCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        FullDescription = c.String(),
                        BigImageData = c.Binary(),
                        BigImageMimeType = c.String(),
                        SmallImageData = c.Binary(),
                        SmallImageMimeType = c.String(),
                        Cateegory_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProgramId)
                .ForeignKey("dbo.ProgramCategories", t => t.Cateegory_CategoryId)
                .Index(t => t.Cateegory_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Programs", "Cateegory_CategoryId", "dbo.ProgramCategories");
            DropIndex("dbo.Programs", new[] { "Cateegory_CategoryId" });
            DropTable("dbo.Programs");
            DropTable("dbo.ProgramCategories");
        }
    }
}
