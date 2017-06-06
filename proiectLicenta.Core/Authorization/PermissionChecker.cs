using Abp.Authorization;
using proiectLicenta.Authorization.Roles;
using proiectLicenta.MultiTenancy;
using proiectLicenta.Users;

namespace proiectLicenta.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
