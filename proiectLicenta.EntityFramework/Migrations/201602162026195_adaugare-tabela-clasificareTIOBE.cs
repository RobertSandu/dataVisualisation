namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adaugaretabelaclasificareTIOBE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClasificareTIOBEs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProgrammingLanguageName = c.String(),
                        Year = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClasificareTIOBEs");
        }
    }
}
