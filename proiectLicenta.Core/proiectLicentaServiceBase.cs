using Abp;

namespace proiectLicenta
{
    public class proiectLicentaServiceBase : AbpServiceBase
    {
        public proiectLicentaServiceBase()
        {
            LocalizationSourceName = proiectLicentaConsts.LocalizationSourceName;
        }
    }
}
