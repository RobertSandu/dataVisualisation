using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Abp.Zero.EntityFramework;
using proiectLicenta.Authorization.Roles;
using proiectLicenta.ClasificariTIOBE;
using proiectLicenta.DateGithub;
using proiectLicenta.DateStackOverflow;
using proiectLicenta.MultiTenancy;
using proiectLicenta.Users;

namespace proiectLicenta.EntityFramework
{
    public class proiectLicentaDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<ClasificareTIOBE> ClasificariTIOBE { get; set; }
        public virtual IDbSet<RulareJobDateGithub> RulariJobDateGithub { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; } 
        public virtual IDbSet<LinkType> LinkTypes { get; set; }
        public virtual IDbSet<Post> Posts { get; set; }
        public virtual IDbSet<PostLink> PostLinks { get; set; }
        public virtual IDbSet<PostType> PostTypes { get; set; }
        public virtual IDbSet<UserStackOverflow> UsersStackOverflow { get; set; }
        public virtual IDbSet<Vote> Votes { get; set; }
        public virtual IDbSet<VoteType> VoteTypes { get; set; }   
        public virtual IDbSet<TagGrouping> TagGroupings { get; set; } 
        public virtual IDbSet<TagAppearance> TagAppearances { get; set; }
        public virtual IDbSet<TagTotalAppearance> TagTotalAppearances { get; set; }
        public virtual IDbSet<USAUsersCount> USAUsersCounts { get; set; }
        public virtual IDbSet<WorldUsersCount> WorldUsersCounts { get; set; }
        public virtual IDbSet<GithubStatistic> GithubStatistics { get; set; }
        public virtual IDbSet<AnswersPerDay> AnswersPerDays { get; set; }
        public virtual IDbSet<AnswersPerHour> AnswersPerHours { get; set; }
        public virtual IDbSet<AnswersPerDayAndHour> AnswersPerDaysAndHours { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public proiectLicentaDbContext()
            : base("Default")
        {
            
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in proiectLicentaDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of proiectLicentaDbContext since ABP automatically handles it.
         */
        public proiectLicentaDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
           
        }

        //This constructor is used in tests
        public proiectLicentaDbContext(DbConnection connection)
            : base(connection, true)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<USAUsersCount>().Property(x => x.Latitude).HasPrecision(7, 4);
            modelBuilder.Entity<USAUsersCount>().Property(x => x.Longitude).HasPrecision(7,4);

            base.OnModelCreating(modelBuilder);
        }
    }
}
