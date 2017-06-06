using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Threading.BackgroundWorkers;
using Abp.Zero;
using Abp.Zero.Configuration;
using proiectLicenta.Authorization;
using proiectLicenta.Authorization.Roles;
using proiectLicenta.DateGithub;
using proiectLicenta.DateStackOverflow;

namespace proiectLicenta
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class proiectLicentaCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = true;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    proiectLicentaConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "proiectLicenta.Localization.Source"
                        )
                    )
                );

            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Authorization.Providers.Add<proiectLicentaAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            workManager.Add(IocManager.Resolve<PreluareDateGithubPassiveWorker>());
        }
    }
}
