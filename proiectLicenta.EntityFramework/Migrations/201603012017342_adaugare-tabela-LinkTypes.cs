namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdaugareTabelaLinkTypes : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            DropTable("dbo.LinkTypes");
        }
    }
}