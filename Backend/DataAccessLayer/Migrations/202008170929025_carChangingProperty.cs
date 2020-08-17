namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carChangingProperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CategoryId", "dbo.CarCategories");
            DropIndex("dbo.Cars", new[] { "CategoryId" });
            AlterColumn("dbo.Cars", "CategoryId", c => c.Int());
            CreateIndex("dbo.Cars", "CategoryId");
            AddForeignKey("dbo.Cars", "CategoryId", "dbo.CarCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CategoryId", "dbo.CarCategories");
            DropIndex("dbo.Cars", new[] { "CategoryId" });
            AlterColumn("dbo.Cars", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "CategoryId");
            AddForeignKey("dbo.Cars", "CategoryId", "dbo.CarCategories", "Id", cascadeDelete: true);
        }
    }
}
