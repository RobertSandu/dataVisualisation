using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using proiectLicenta.EntityFramework;

namespace proiectLicenta
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(proiectLicentaCoreModule))]
    public class proiectLicentaDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
