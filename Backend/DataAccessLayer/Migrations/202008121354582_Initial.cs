namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarRents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateStartRent = c.DateTime(nullable: false),
                        DaysRentAmount = c.Int(nullable: false),
                        CarId = c.Int(),
                        ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.CarId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Year = c.Int(nullable: false),
                        Color = c.String(nullable: false),
                        Carsase = c.String(nullable: false),
                        MaxPassengersAmount = c.String(nullable: false),
                        ImgSrc = c.String(nullable: false),
                        Category = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarRents", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.CarRents", "CarId", "dbo.Cars");
            DropIndex("dbo.CarRents", new[] { "ClientId" });
            DropIndex("dbo.CarRents", new[] { "CarId" });
            DropTable("dbo.Clients");
            DropTable("dbo.Cars");
            DropTable("dbo.CarRents");
        }
    }
}
