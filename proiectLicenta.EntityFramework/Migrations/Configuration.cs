using System.Data.Entity.Migrations;
using proiectLicenta.Migrations.SeedData;

namespace proiectLicenta.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<proiectLicenta.EntityFramework.proiectLicentaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "proiectLicenta";

            //this.CommandTimeout = 60*60;
        }

        protected override void Seed(proiectLicenta.EntityFramework.proiectLicentaDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
