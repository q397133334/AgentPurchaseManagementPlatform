using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AgentPurchaseManagementPlatform.MultiTenancy.Dto;

namespace AgentPurchaseManagementPlatform.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

