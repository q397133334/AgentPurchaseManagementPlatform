using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AgentPurchaseManagementPlatform.Account;
using AgentPurchaseManagementPlatform.Users.Dto;
using System.Threading.Tasks;
using System.Linq;
using AgentPurchaseManagementPlatform.Authorization;

namespace AgentPurchaseManagementPlatform.Users
{
    public class BalanceRecordAppService : AsyncCrudAppService<BalanceRecord, BalanceDto, int, PagedBalanceResultRequestDto, CreateBalanceDto, EditBalanceDto>
    {

        private IRepository<BalanceRecord> _balanceRecordrepository;
        private IRepository<Authorization.Users.User, long> _userRepository;

        public BalanceRecordAppService(IRepository<BalanceRecord> balanceRecordrepository,
            IRepository<Authorization.Users.User, long> userRepository) : base(balanceRecordrepository)
        {
            _balanceRecordrepository = balanceRecordrepository;
            _userRepository = userRepository;
        }

        public override async Task<BalanceDto> Create(CreateBalanceDto input)
        {
            var user = _userRepository.Get(input.UserId);
            user.Balance = user.Balance.HasValue ? user.Balance : 0;
            user.Balance += input.Money;
            await _userRepository.UpdateAsync(user);
            return await base.Create(input);
        }

        //public override Task<PagedResultDto<BalanceDto>> GetAll(PagedBalanceResultRequestDto input)
        //{
        //    var query = _balanceRecordrepository.GetAll().Where(q => q.UserId == input.UserId);
        //    return base.GetAll(input);
        //}

        protected override IQueryable<BalanceRecord> CreateFilteredQuery(PagedBalanceResultRequestDto input)
        {
            return Repository.GetAll().Where(q => q.UserId == input.UserId);
        }
    }
}
