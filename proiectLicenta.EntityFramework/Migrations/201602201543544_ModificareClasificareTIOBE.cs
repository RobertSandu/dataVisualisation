namespace proiectLicenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificareClasificareTIOBE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClasificareTIOBEs", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.ClasificareTIOBEs", "Percent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ClasificareTIOBEs", "Position");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClasificareTIOBEs", "Position", c => c.Int(nullable: false));
            DropColumn("dbo.ClasificareTIOBEs", "Percent");
            DropColumn("dbo.ClasificareTIOBEs", "Month");
        }
    }
}
