namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IX_Stack_Overflow_Id : DbMigration
    {
        public override void Up()
        {
            //AddPrimaryKey("dbo.Comments", "Id");
            //AddPrimaryKey("dbo.LinkTypes", "Id");
            //AddPrimaryKey("dbo.PostLinks", "Id");
            //AddPrimaryKey("dbo.Posts", "Id");
            //AddPrimaryKey("dbo.PostTypes", "Id");
            //AddPrimaryKey("dbo.UserStackOverflows", "Id");
            //AddPrimaryKey("dbo.Votes", "Id");
            //AddPrimaryKey("dbo.VoteTypes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Comments", "Id");
            DropPrimaryKey("dbo.LinkTypes", "Id");
            DropPrimaryKey("dbo.PostLinks", "Id");
            DropPrimaryKey("dbo.Posts", "Id");
            DropPrimaryKey("dbo.PostTypes", "Id");
            DropPrimaryKey("dbo.UserStackOverflows", "Id");
            DropPrimaryKey("dbo.Votes", "Id");
            DropPrimaryKey("dbo.VoteTypes", "Id");
        }
    }
}
