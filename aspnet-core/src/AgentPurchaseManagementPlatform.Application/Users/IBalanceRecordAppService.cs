using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using AgentPurchaseManagementPlatform.Users.Dto;

namespace AgentPurchaseManagementPlatform.Users
{
    public interface IBalanceRecordAppService : IAsyncCrudAppService<BalanceDto, int, PagedBalanceResultRequestDto, CreateBalanceDto, EditBalanceDto>
    {
    }
}
