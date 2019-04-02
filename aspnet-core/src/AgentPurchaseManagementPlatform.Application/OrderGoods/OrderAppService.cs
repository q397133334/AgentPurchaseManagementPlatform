using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AgentPurchaseManagementPlatform.OrderGoods.Dto;
using AgentPurchaseManagementPlatform.Authorization.Users;
using Abp.Authorization;
using AgentPurchaseManagementPlatform.Authorization;
using Abp.UI;
using Abp.Linq.Extensions;
using AgentPurchaseManagementPlatform.Configuration;
using AgentPurchaseManagementPlatform.Account;

namespace AgentPurchaseManagementPlatform.OrderGoods
{
    public class OrderAppService : AgentPurchaseManagementPlatformAppServiceBase, IOrderAppService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<BalanceRecord> _balanceRecordrepository;
        public OrderAppService(IRepository<Order> orderRepository,
            IRepository<User, long> userRepository,
             IRepository<BalanceRecord> balanceRecordrepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _balanceRecordrepository = balanceRecordrepository;
        }

        [AbpAuthorize(PermissionNames.Pages_Orders_Add)]
        public async Task CreateOrder(CreateOrderDto inputDto)
        {
            var order = ObjectMapper.Map<Order>(inputDto);
            order.State = OrderType.等待订购;
            order.CreatorUserId = AbpSession.UserId;
            order.CreationTime = DateTime.Now;
            order.ChinalogisticsPrice = decimal.Parse(await SettingManager.GetSettingValueForApplicationAsync(AppSettingNames.ChinalogisticsPrice));
            await _orderRepository.InsertAsync(order);
        }


        [AbpAuthorize(PermissionNames.Pages_Orders_Edit)]
        public async Task<EditOrderDto> GetEditOrder(int orderId)
        {
            var order = await _orderRepository.GetAsync(orderId);
            return ObjectMapper.Map<EditOrderDto>(order);
        }

        [AbpAuthorize(PermissionNames.Pages_Orders_Edit)]
        public async Task EditOrder(EditOrderDto input)
        {
            var order = await _orderRepository.GetAsync(input.Id);
            if (order == null)
                throw new UserFriendlyException("0001", "未找到订单信息");
            //if (order.State >= OrderType.交易成功)
            //    throw new UserFriendlyException("0002", "已完成或者以失败的订单无法修改");

            ObjectMapper.Map(input, order);
            order.LastModificationTime = DateTime.Now;
            order.LastModifierUserId = AbpSession.UserId;
            await _orderRepository.UpdateAsync(order);
        }

        public async Task<OrderListDto> GetOrder(int orderId)
        {
            var order = await _orderRepository.GetAsync(orderId);
            return ObjectMapper.Map<OrderListDto>(order);
        }

        [AbpAuthorize(PermissionNames.Data_Admin, PermissionNames.Data_Taobao, PermissionNames.Data_Usa)]
        public PagedResultDto<OrderListDto> GetOrders(PagedOrderResultRequestDto inputDto)
        {
            var query = from o in _orderRepository.GetAll()
                        select o;

            if (IsGranted(PermissionNames.Data_Admin))
            {

            }
            else if (IsGranted(PermissionNames.Data_Taobao))
            {
                query = query.Where(q => q.CreatorUserId == AbpSession.UserId);
            }
            else if (IsGranted(PermissionNames.Data_Usa))
            {
                query = query.Where(q => q.AccountId == AbpSession.UserId);
            }
            if (string.IsNullOrEmpty(inputDto.Key) == false)
            {
                query = query.Where(q => q.TaobaoShop.Contains(inputDto.Key)
                      || q.ProductName.Contains(inputDto.Key)
                      || q.TransportNumber == inputDto.Key
                      || q.UsaLogisticsNumber == inputDto.Key
                      || q.ChinaLogisticsNumber == inputDto.Key
                        );
            }

            query = query.WhereIf(Convert.ToInt16(inputDto.OrderType) > -1, q => q.State == inputDto.OrderType)
                            .WhereIf(inputDto.DwonTo.HasValue, q => q.ChinaDateTime <= inputDto.DwonTo)
                            .WhereIf(inputDto.DwonFrom.HasValue, q => q.ChinaDateTime >= inputDto.DwonFrom)
                            .WhereIf(inputDto.ComplateFrom.HasValue, q => q.LastModificationTime >= inputDto.ComplateFrom && q.State == OrderType.交易成功)
                            .WhereIf(inputDto.ComplateTo.HasValue, q => q.LastModificationTime <= inputDto.ComplateTo && q.State == OrderType.交易成功);


            query.OrderBy(q => q.State).OrderByDescending(q => q.LastModificationTime).OrderBy(q => q.TransportNumber);

            var orders = query.Skip(inputDto.SkipCount).Take(inputDto.MaxResultCount).ToList();
            var userIds = orders.Select(q => q.AccountId).ToList();
            userIds.AddRange(orders.Select(q => q.CreatorUserId ?? 0).ToList());
            userIds = userIds.Distinct().ToList();

            var users = _userRepository.GetAll().Where(q => userIds.Contains(q.Id)).ToList();
            foreach (var item in orders)
            {
                var account = users.Where(q => q.Id == item.AccountId).FirstOrDefault();
                var create = users.Where(q => q.Id == item.CreatorUserId).FirstOrDefault();
                if (account != null)
                {
                    item.Account = account.Name;
                }
                if (create != null)
                {
                    item.TaobaoShop = create.Name;
                }
                if (item.OtherDesc != null)
                {
                    item.OtherDesc = item.OtherDesc.Trim('\n').Trim('\r').Replace("\n", "<br/>");
                }
            }
            return new PagedResultDto<OrderListDto>(query.Count(), ObjectMapper.Map<List<OrderListDto>>(orders));
        }


        [AbpAuthorize(PermissionNames.Pages_Orders_Down)]
        public async Task<DownOrderDto> GetDownOrder(int orderId)
        {
            var order = await _orderRepository.GetAsync(orderId);
            return ObjectMapper.Map<DownOrderDto>(order);
        }

        [AbpAuthorize(PermissionNames.Pages_Orders_Down)]
        public async Task DownOrder(DownOrderDto input)
        {

            var order = await _orderRepository.GetAsync(input.Id);
            if (order == null)
                throw new UserFriendlyException("0001", "未找到订单信息");
            if (order.State >= OrderType.交易成功)
                throw new UserFriendlyException("0002", "已完成或者以失败的订单无法修改");

            ObjectMapper.Map(input, order);
            order.LastModificationTime = DateTime.Now;
            order.LastModifierUserId = AbpSession.UserId;

            if (order.State == OrderType.已经订购)
            {
                var user = _userRepository.Get(AbpSession.UserId.Value);
                user.Balance = user.Balance - order.TrueBuyPrice;
                await _balanceRecordrepository.InsertAsync(new BalanceRecord()
                {
                    Money=order.TrueBuyPrice.Value,
                    UserId = AbpSession.UserId.Value,
                    Desc = $"订购产品扣款：{order.TrueBuyPrice},产品ID：{order.Id}"
                });
            }


            await _orderRepository.UpdateAsync(order);
        }

        [AbpAuthorize(PermissionNames.Pages_Orders_OtherDesc)]
        public async Task AddOtherDesc(int orderId, string desc)
        {
            var order = _orderRepository.Get(orderId);
            order.OtherDesc += $"\n\r{desc}";
            await _orderRepository.UpdateAsync(order);

        }

        [AbpAuthorize(PermissionNames.Pages_Orders_Complate)]
        public async Task Complate(int orderId)
        {
            var order = _orderRepository.Get(orderId);
            order.State = OrderType.交易成功;
            order.Huilv = decimal.Parse(await SettingManager.GetSettingValueForApplicationAsync(AppSettingNames.USD_CYN));
            //实际销售价格-实际购买价格-转运运费-国内运费
            order.Lirun = order.TrueSalePrice - (order.TrueBuyPrice * order.Huilv) - (order.TransportPrice + order.Huilv) - order.ChinalogisticsPrice;

            await _orderRepository.UpdateAsync(order);
        }
    }
}
