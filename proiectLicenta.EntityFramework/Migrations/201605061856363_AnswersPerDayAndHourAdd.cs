namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnswersPerDayAndHourAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswersPerDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answers = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnswersPerHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answers = c.Int(nullable: false),
                        Hour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnswersPerHours");
            DropTable("dbo.AnswersPerDays");
        }
    }
}
