using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using AgentPurchaseManagementPlatform.Configuration.Dto;
using Abp.Threading;

namespace AgentPurchaseManagementPlatform.Configuration
{
    public class ReceivingAppService : AgentPurchaseManagementPlatformAppServiceBase, IReceivingAppService
    {
        private readonly IRepository<Receiving> _repositoryReceiving;

        private readonly IRepository<ReceivingPersion> _repositoryReceivingPersion;

        public ReceivingAppService(IRepository<Receiving> repositoryReceiving,
            IRepository<ReceivingPersion> repositoryReceivingPersion)
        {
            _repositoryReceiving = repositoryReceiving;
            _repositoryReceivingPersion = repositoryReceivingPersion;
        }

        #region receivings

        public async Task<List<ReceivingDto>> GetReceivings()
        {
            var receivings = await _repositoryReceiving.GetAllListAsync();
            return ObjectMapper.Map<List<ReceivingDto>>(receivings);
        }

        public async Task<ReceivingDto> GetReceiving(int id)
        {
            var receiving = _repositoryReceiving.GetAll().Where(q => q.Id == id).FirstOrDefault();
            if (receiving == null)
                throw new UserFriendlyException("未找到仓库信息");
            return ObjectMapper.Map<ReceivingDto>(receiving);
        }

        public async Task CreateOrUpdate(CreateOrUpdateReceivingDto createOrUpdateReceivingDto)
        {
            if (createOrUpdateReceivingDto.Id > 0)
            {
                await update(createOrUpdateReceivingDto);
            }
            else
            {
                await create(createOrUpdateReceivingDto);
            }
        }

        public async Task Delete(int id)
        {
            var receiving = get(id);
            await _repositoryReceiving.DeleteAsync(receiving);

        }
        #endregion

        #region persion
        public async Task createOrUpdatePersion(CreateOrUpdateReceivingPersionDto createOrUpdateReceivingPersionDto)
        {
            if (createOrUpdateReceivingPersionDto.Id > 0)
            {
                await updatePersion(createOrUpdateReceivingPersionDto);
            }
            else
            {
                await createPersion(createOrUpdateReceivingPersionDto);
            }
        }

        public async Task DeletePersion(int id)
        {
            var persion = getPersion(id);
            await _repositoryReceivingPersion.DeleteAsync(persion);
        }

        public async Task<List<ReceivingPersionDto>> GetPersions(int receivingId)
        {
            var persions = _repositoryReceivingPersion.GetAll().Where(q => q.ReceivingId == receivingId).ToList();
            return ObjectMapper.Map<List<ReceivingPersionDto>>(persions);
        }

        public async Task<ReceivingPersionDto> GetPersion(int id)
        {
            var persion = getPersion(id);
            return ObjectMapper.Map<ReceivingPersionDto>(persion);
        }
        #endregion

        #region 私有方法

        #region receiving

        /// <summary>
        /// 获取收货信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Receiving get(int id)
        {
            var receiving = _repositoryReceiving.GetAll().Where(q => q.Id == id).FirstOrDefault();
            if (receiving == null)
                throw new UserFriendlyException("未找到收货信息");
            return receiving;
        }

        /// <summary>
        /// 创建新的收货信息
        /// </summary>
        /// <param name="createOrUpdateReceivingDto"></param>
        /// <returns></returns>
        private async Task create(CreateOrUpdateReceivingDto createOrUpdateReceivingDto)
        {
            await _repositoryReceiving.InsertAsync(new Receiving() { Address = createOrUpdateReceivingDto.Address });
        }

        /// <summary>
        /// 更新收货信息
        /// </summary>
        /// <param name="createOrUpdateReceivingDto"></param>
        /// <returns></returns>
        private async Task update(CreateOrUpdateReceivingDto createOrUpdateReceivingDto)
        {
            var receiving = get(createOrUpdateReceivingDto.Id);
            receiving.Address = createOrUpdateReceivingDto.Address;
            await _repositoryReceiving.UpdateAsync(receiving);
        }
        #endregion

        #region persion

        private ReceivingPersion getPersion(int id)
        {
            var persion = _repositoryReceivingPersion.GetAll().Where(q => q.Id == id).FirstOrDefault();
            if (persion == null)
                throw new UserFriendlyException("未找到收货人");
            return persion;
        }

        private async Task createPersion(CreateOrUpdateReceivingPersionDto createOrUpdateReceivingPersionDto)
        {
            var persion = new ReceivingPersion();
            persion.ReceivingId = createOrUpdateReceivingPersionDto.ReceivingId;
            persion.Name = createOrUpdateReceivingPersionDto.Name;
            await _repositoryReceivingPersion.InsertAsync(persion);
        }

        private async Task updatePersion(CreateOrUpdateReceivingPersionDto createOrUpdateReceivingPersionDto)
        {
            var persion = this.getPersion(createOrUpdateReceivingPersionDto.Id);
            persion.Name = createOrUpdateReceivingPersionDto.Name;
            await _repositoryReceivingPersion.UpdateAsync(persion);
        }

        #endregion

        #endregion

    }
}
