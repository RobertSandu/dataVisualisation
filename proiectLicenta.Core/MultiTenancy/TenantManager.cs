using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using proiectLicenta.Authorization.Roles;
using proiectLicenta.Editions;
using proiectLicenta.Users;

namespace proiectLicenta.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager
            )
        {
        }
    }
}