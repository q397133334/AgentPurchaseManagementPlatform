using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AgentPurchaseManagementPlatform.OrderGoods.Dto;

namespace AgentPurchaseManagementPlatform.OrderGoods
{
    public interface IOrderAppService : IApplicationService
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        Task CreateOrder(CreateOrderDto inputDto);

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        PagedResultDto<OrderListDto> GetOrders(PagedOrderResultRequestDto inputDto);

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<OrderListDto> GetOrder(int orderId);

        /// <summary>
        /// 获取编辑订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<EditOrderDto> GetEditOrder(int orderId);

        /// <summary>
        /// 编辑订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task EditOrder(EditOrderDto input);

        /// <summary>
        /// 获取订购订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<DownOrderDto> GetDownOrder(int orderId);

        /// <summary>
        /// 订购订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DownOrder(DownOrderDto input);

        /// <summary>
        /// 增加其他说明
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        Task AddOtherDesc(int orderId, string desc);

        Task Complate(int orderId);
    }
}
