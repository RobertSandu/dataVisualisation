using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Modules;
using Abp.Runtime.Caching.Redis;
using Abp.Web.Mvc;
using Abp.Zero.Configuration;
using proiectLicenta.Api;

namespace proiectLicenta.Web
{
    [DependsOn(
        typeof(proiectLicentaDataModule), 
        typeof(proiectLicentaApplicationModule), 
        typeof(proiectLicentaWebApiModule),
        typeof(AbpWebMvcModule),
        typeof(AbpRedisCacheModule))]
    public class proiectLicentaWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Navigation.Providers.Add<proiectLicentaNavigationProvider>();

            Configuration.Caching.UseRedis();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
