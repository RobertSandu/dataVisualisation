namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adaugareTabelaTagAppearances : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagAppearances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag1 = c.String(maxLength: 150),
                        Tag2 = c.String(maxLength: 150),
                        Appearences = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TagAppearances");
        }
    }
}
