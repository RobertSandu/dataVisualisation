namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnswersPerDayAndHourTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswersPerDayAndHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answers = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                        Day = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnswersPerDayAndHours");
        }
    }
}
