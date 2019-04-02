using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AgentPurchaseManagementPlatform.Roles.Dto;
using AgentPurchaseManagementPlatform.Users.Dto;

namespace AgentPurchaseManagementPlatform.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
