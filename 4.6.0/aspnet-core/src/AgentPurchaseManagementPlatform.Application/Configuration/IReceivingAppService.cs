using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentPurchaseManagementPlatform.Configuration.Dto;

namespace AgentPurchaseManagementPlatform.Configuration
{
    public interface IReceivingAppService : IApplicationService
    {
        Task CreateOrUpdate(CreateOrUpdateReceivingDto createOrUpdateReceivingDto);

        Task Delete(int id);

        Task<List<ReceivingDto>> GetReceivings();

        Task<ReceivingDto> GetReceiving(int id);

        Task createOrUpdatePersion(CreateOrUpdateReceivingPersionDto createOrUpdateReceivingPersionDto);

        Task DeletePersion(int id);

        Task<List<ReceivingPersionDto>> GetPersions(int receivingId);

        Task<ReceivingPersionDto> GetPersion(int id);

    }
}
