namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableWorldUsersCount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorldUsersCounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                        NumberOfUsers = c.Int(nullable: false),
                        NumberOfUsersUnder20 = c.Int(),
                        NumberOfUsersBetween20And24 = c.Int(),
                        NumberOfUsersBetween25And29 = c.Int(),
                        NumberOfUsersBetween30And34 = c.Int(),
                        NumberOfUsersBetween35And39 = c.Int(),
                        NumberOfUsersBetween40And49 = c.Int(),
                        NumberOfUsersBetween50And60 = c.Int(),
                        NumberOfUsersOvers60 = c.Int(),
                        NumberOfUsersWithNoAge = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorldUsersCounts");
        }
    }
}
