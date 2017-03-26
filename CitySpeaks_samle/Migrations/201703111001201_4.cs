namespace CitySpeaks_samle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Programs", name: "Cateegory_CategoryId", newName: "Category_CategoryId");
            RenameIndex(table: "dbo.Programs", name: "IX_Cateegory_CategoryId", newName: "IX_Category_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Programs", name: "IX_Category_CategoryId", newName: "IX_Cateegory_CategoryId");
            RenameColumn(table: "dbo.Programs", name: "Category_CategoryId", newName: "Cateegory_CategoryId");
        }
    }
}
