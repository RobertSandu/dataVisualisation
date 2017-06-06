namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class USAUsersCount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.USAUsersCounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        State = c.String(),
                        NumberOfUsers = c.Int(nullable: false),
                        Longitude = c.Decimal(nullable: false, precision: 7, scale: 4),
                        Latitude = c.Decimal(nullable: false, precision: 7, scale: 4),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.USAUsersCounts");
        }
    }
}
