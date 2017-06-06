using System.Threading.Tasks;
using Abp.Application.Services;
using proiectLicenta.Users.Dto;

namespace proiectLicenta.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}