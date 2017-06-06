using Abp.Application.Features;
using proiectLicenta.Authorization.Roles;
using proiectLicenta.MultiTenancy;
using proiectLicenta.Users;

namespace proiectLicenta.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}