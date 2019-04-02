using Abp.Domain.Repositories;
using Abp.GeneralTree;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgentPurchaseManagementPlatform.Logistics
{
    public class WarehouseApplication : AgentPurchaseManagementPlatformAppServiceBase, IWarehouseApplication
    {
        private readonly IGeneralTreeManager<Warehouse, long> _generalWarehouseTreeManager;
        private IRepository<Warehouse, long> _repository;

        public WarehouseApplication(IGeneralTreeManager<Warehouse, long> generalWarehouseTreeManager,
            IRepository<Warehouse, long> repository)
        {
            _generalWarehouseTreeManager = generalWarehouseTreeManager;
            _repository = repository;
        }

        public async Task AddAsync(Warehouse warehouse)
        {
            await _generalWarehouseTreeManager.CreateAsync(warehouse);
        }

        public async Task DeleteAsync(long id)
        {
            await _generalWarehouseTreeManager.DeleteAsync(id);
        }

        public async Task<List<Warehouse>> GetWarehousesAsync(long? parentId)
        {
            return (await _repository.GetAllListAsync()).Where(q => q.ParentId == parentId).ToList();
        }

        public async Task UpdateAsync(Warehouse warehouse)
        {
            await _generalWarehouseTreeManager.UpdateAsync(warehouse);
        }
    }
}
