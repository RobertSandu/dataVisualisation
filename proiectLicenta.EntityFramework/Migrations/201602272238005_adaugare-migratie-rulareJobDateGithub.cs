namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adaugaremigratierulareJobDateGithub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RulareJobDateGithubs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RulareJobDateGithubs");
        }
    }
}
