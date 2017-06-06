namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adaugareTagGroupingsStackOverflow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagGroupings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Appearances = c.Int(nullable: false),
                        Tags = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TagGroupings");
        }
    }
}
