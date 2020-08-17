namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "CarCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "CarCategoryId");
            AddForeignKey("dbo.Cars", "CarCategoryId", "dbo.CarCategories", "Id", cascadeDelete: true);
            DropColumn("dbo.Cars", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Category", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cars", "CarCategoryId", "dbo.CarCategories");
            DropIndex("dbo.Cars", new[] { "CarCategoryId" });
            DropColumn("dbo.Cars", "CarCategoryId");
            DropTable("dbo.CarCategories");
        }
    }
}
