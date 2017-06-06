namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAgeBracketsToUsaUsersCount2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USAUsersCounts", "NumberOfUsersWithNoAge", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.USAUsersCounts", "NumberOfUsersWithNoAge");
        }
    }
}
