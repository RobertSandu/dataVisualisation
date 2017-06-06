namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adaugareTabeleStackOverflow : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Comments",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            PostId = c.Int(nullable: false),
            //            Text = c.String(nullable: false, maxLength: 700),
            //            Score = c.Int(),
            //            UserId = c.Int(),
            //        })
            //    .PrimaryKey(t => new { t.Id, t.CreationDate, t.PostId, t.Text });
            
            //CreateTable(
            //    "dbo.PostLinks",
            //    c => new
            //        {
            //            CreationDate = c.DateTime(nullable: false),
            //            PostId = c.Int(nullable: false),
            //            RelatedPostId = c.Int(nullable: false),
            //            LinkTypeId = c.Int(nullable: false),
            //            Id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.CreationDate, t.PostId, t.RelatedPostId, t.LinkTypeId });
            
            //CreateTable(
            //    "dbo.Posts",
            //    c => new
            //        {
            //            Body = c.String(nullable: false, maxLength: 128),
            //            CreationDate = c.DateTime(nullable: false),
            //            LastActivityDate = c.DateTime(nullable: false),
            //            PostTypeId = c.Int(nullable: false),
            //            Score = c.Int(nullable: false),
            //            ViewCount = c.Int(nullable: false),
            //            AcceptedAnswerId = c.Int(),
            //            AnswerCount = c.Int(),
            //            ClosedDate = c.DateTime(),
            //            CommentCount = c.Int(),
            //            CommunityOwnedDate = c.DateTime(),
            //            FavoriteCount = c.Int(),
            //            LastEditDate = c.DateTime(),
            //            LastEditorDisplayName = c.String(maxLength: 40),
            //            LastEditorUserId = c.Int(),
            //            OwnerUserId = c.Int(),
            //            ParentId = c.Int(),
            //            Tags = c.String(maxLength: 150),
            //            Title = c.String(maxLength: 250),
            //            Id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Body, t.CreationDate, t.LastActivityDate, t.PostTypeId, t.Score, t.ViewCount });
            
            //CreateTable(
            //    "dbo.PostTypes",
            //    c => new
            //        {
            //            Type = c.String(nullable: false, maxLength: 50),
            //            Id = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Type);
            
            //CreateTable(
            //    "dbo.UserStackOverflows",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            DisplayName = c.String(nullable: false, maxLength: 40),
            //            DownVotes = c.Int(nullable: false),
            //            LastAccessDate = c.DateTime(nullable: false),
            //            Reputation = c.Int(nullable: false),
            //            UpVotes = c.Int(nullable: false),
            //            Views = c.Int(nullable: false),
            //            AboutMe = c.String(),
            //            Age = c.Int(),
            //            EmailHash = c.String(maxLength: 40),
            //            Location = c.String(maxLength: 100),
            //            WebsiteUrl = c.String(maxLength: 200),
            //            AccountId = c.Int(),
            //        })
            //    .PrimaryKey(t => new { t.Id, t.CreationDate, t.DisplayName, t.DownVotes, t.LastAccessDate, t.Reputation, t.UpVotes, t.Views });
            
            //CreateTable(
            //    "dbo.Votes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            PostId = c.Int(nullable: false),
            //            VoteTypeId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            UserId = c.Int(),
            //            BountyAmount = c.Int(),
            //        })
            //    .PrimaryKey(t => new { t.Id, t.PostId, t.VoteTypeId, t.CreationDate });
            
            //CreateTable(
            //    "dbo.VoteTypes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false),
            //            Name = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => new { t.Id, t.Name });
            
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VoteTypes");
            DropTable("dbo.Votes");
            DropTable("dbo.UserStackOverflows");
            DropTable("dbo.PostTypes");
            DropTable("dbo.Posts");
            DropTable("dbo.PostLinks");
            DropTable("dbo.Comments");
        }
    }
}
