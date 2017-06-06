namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTagTotalAppearance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagTotalAppearances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tag = c.String(maxLength: 150),
                        Appearences = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TagTotalAppearances");
        }
    }
}
