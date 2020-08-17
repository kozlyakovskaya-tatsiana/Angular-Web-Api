namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Carcase", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "MaxPassengersAmount", c => c.Int(nullable: false));
            DropColumn("dbo.Cars", "Carsase");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Carsase", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "MaxPassengersAmount", c => c.String(nullable: false));
            DropColumn("dbo.Cars", "Carcase");
        }
    }
}
