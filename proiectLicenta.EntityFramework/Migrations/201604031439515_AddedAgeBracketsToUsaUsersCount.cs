namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAgeBracketsToUsaUsersCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USAUsersCounts", "NumberOfUsersUnder20", c => c.Int());
            AddColumn("dbo.USAUsersCounts", "NumberOfUsersBetween20And24", c => c.Int());
            AddColumn("dbo.USAUsersCounts", "NumberOfUsersBetween25And29", c => c.Int());
            AddColumn("dbo.USAUsersCounts", "NumberOfUsersBetween30And34", c => c.Int());
            AddColumn("dbo.USAUsersCounts", "NumberOfUsersBetween35And39", c => c.Int());
            AddColumn("dbo.USAUsersCounts", "NumberOfUsersBetween40And49", c => c.Int());
            AddColumn("dbo.USAUsersCounts", "NumberOfUsersBetween50And60", c => c.Int());
            AddColumn("dbo.USAUsersCounts", "NumberOfUsersOvers60", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.USAUsersCounts", "NumberOfUsersOvers60");
            DropColumn("dbo.USAUsersCounts", "NumberOfUsersBetween50And60");
            DropColumn("dbo.USAUsersCounts", "NumberOfUsersBetween40And49");
            DropColumn("dbo.USAUsersCounts", "NumberOfUsersBetween35And39");
            DropColumn("dbo.USAUsersCounts", "NumberOfUsersBetween30And34");
            DropColumn("dbo.USAUsersCounts", "NumberOfUsersBetween25And29");
            DropColumn("dbo.USAUsersCounts", "NumberOfUsersBetween20And24");
            DropColumn("dbo.USAUsersCounts", "NumberOfUsersUnder20");
        }
    }
}
