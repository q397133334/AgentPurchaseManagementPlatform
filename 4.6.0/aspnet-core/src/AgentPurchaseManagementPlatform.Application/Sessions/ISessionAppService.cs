using System.Threading.Tasks;
using Abp.Application.Services;
using AgentPurchaseManagementPlatform.Sessions.Dto;

namespace AgentPurchaseManagementPlatform.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
