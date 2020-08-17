namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingCar2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "CostRentForDay", c => c.Double(nullable: false));
            AlterColumn("dbo.Cars", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Category", c => c.String(nullable: false));
            DropColumn("dbo.Cars", "CostRentForDay");
        }
    }
}
