using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgentPurchaseManagementPlatform.Users.Dto
{
    public class PagedBalanceResultRequestDto : PagedResultRequestDto
    {
        public long UserId { get; set; }
    }
}
