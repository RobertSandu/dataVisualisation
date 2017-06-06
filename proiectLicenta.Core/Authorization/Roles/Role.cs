using Abp.Authorization.Roles;
using proiectLicenta.MultiTenancy;
using proiectLicenta.Users;

namespace proiectLicenta.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}