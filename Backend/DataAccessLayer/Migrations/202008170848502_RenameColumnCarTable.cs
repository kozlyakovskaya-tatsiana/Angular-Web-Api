namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameColumnCarTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cars", name: "CarCategoryId", newName: "CategoryId");
            RenameIndex(table: "dbo.Cars", name: "IX_CarCategoryId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cars", name: "IX_CategoryId", newName: "IX_CarCategoryId");
            RenameColumn(table: "dbo.Cars", name: "CategoryId", newName: "CarCategoryId");
        }
    }
}
