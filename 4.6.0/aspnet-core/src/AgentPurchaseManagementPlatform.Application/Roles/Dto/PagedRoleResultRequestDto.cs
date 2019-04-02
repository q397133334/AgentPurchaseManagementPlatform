using Abp.Application.Services.Dto;

namespace AgentPurchaseManagementPlatform.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

