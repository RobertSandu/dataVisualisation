using System.Threading.Tasks;
using Abp.Application.Services;
using proiectLicenta.Roles.Dto;

namespace proiectLicenta.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
