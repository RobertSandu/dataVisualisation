using proiectLicenta.EntityFramework;
using EntityFramework.DynamicFilters;

namespace proiectLicenta.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly proiectLicentaDbContext _context;

        public InitialDataBuilder(proiectLicentaDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}
