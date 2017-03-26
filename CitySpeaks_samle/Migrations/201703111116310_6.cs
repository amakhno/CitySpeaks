namespace CitySpeaks_samle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Programs", "Category_CategoryId", "dbo.ProgramCategories");
            DropIndex("dbo.Programs", new[] { "Category_CategoryId" });
            RenameColumn(table: "dbo.Programs", name: "Category_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.Programs", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Programs", "CategoryId");
            AddForeignKey("dbo.Programs", "CategoryId", "dbo.ProgramCategories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Programs", "CategoryId", "dbo.ProgramCategories");
            DropIndex("dbo.Programs", new[] { "CategoryId" });
            AlterColumn("dbo.Programs", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Programs", name: "CategoryId", newName: "Category_CategoryId");
            CreateIndex("dbo.Programs", "Category_CategoryId");
            AddForeignKey("dbo.Programs", "Category_CategoryId", "dbo.ProgramCategories", "CategoryId");
        }
    }
}
