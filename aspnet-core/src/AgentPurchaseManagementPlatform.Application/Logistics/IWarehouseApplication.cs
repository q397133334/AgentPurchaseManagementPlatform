using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgentPurchaseManagementPlatform.Logistics
{
    public interface IWarehouseApplication : IApplicationService
    {
        Task AddAsync(Warehouse warehouse);

        Task<List<Warehouse>> GetWarehousesAsync(long? parentId);

        Task UpdateAsync(Warehouse warehouse);

        Task DeleteAsync(long id);
    }
}
