namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificareNumeClasificareTIOBE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClasificareTIOBEs", "TIOBEYear", c => c.Int(nullable: false));
            AddColumn("dbo.ClasificareTIOBEs", "TIOBEMonth", c => c.Int(nullable: false));
            AddColumn("dbo.ClasificareTIOBEs", "TIOBEPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ClasificareTIOBEs", "Year");
            DropColumn("dbo.ClasificareTIOBEs", "Month");
            DropColumn("dbo.ClasificareTIOBEs", "Percent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClasificareTIOBEs", "Percent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ClasificareTIOBEs", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.ClasificareTIOBEs", "Year", c => c.Int(nullable: false));
            DropColumn("dbo.ClasificareTIOBEs", "TIOBEPercent");
            DropColumn("dbo.ClasificareTIOBEs", "TIOBEMonth");
            DropColumn("dbo.ClasificareTIOBEs", "TIOBEYear");
        }
    }
}
