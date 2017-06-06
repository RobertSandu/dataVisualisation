namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGithubStatisticsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GithubStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatisticDateTime = c.DateTime(nullable: false),
                        CreateEventCount = c.Int(),
                        ForkEventCount = c.Int(),
                        IssuesEventCount = c.Int(),
                        MemberEventCount = c.Int(),
                        PullRequestCount = c.Int(),
                        PushEventCount = c.Int(),
                        WatchEventCount = c.Int(),
                        CreateEventProcentualDifference = c.Double(),
                        ForkEventProcentualDifference = c.Double(),
                        IssuesEventProcentualDifference = c.Double(),
                        MemberEventProcentualDifference = c.Double(),
                        PullRequestProcentualDifference = c.Double(),
                        PushEventProcentualDifference = c.Double(),
                        WatchEventProcentualDifference = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GithubStatistics");
        }
    }
}
