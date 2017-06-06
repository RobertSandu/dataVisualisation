using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace proiectLicenta
{
    [DependsOn(typeof(proiectLicentaCoreModule), typeof(AbpAutoMapperModule))]
    public class proiectLicentaApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
