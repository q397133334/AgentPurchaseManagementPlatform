using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using AgentPurchaseManagementPlatform.OrderGoods;

namespace AgentPurchaseManagementPlatform.OrderGoods.Dto
{
    public class PagedOrderResultRequestDto : PagedResultRequestDto
    {
        public string Key { get; set; }


        public OrderType? OrderType { get; set; }

        /// <summary>
        /// 下单时间开始
        /// </summary>
        public DateTime? DwonFrom { get; set; }//javascript date within timezone

        /// <summary>
        /// 下单时间结束
        /// </summary>
        public DateTime? DwonTo { get; set; }//javascript date within timezone

        /// <summary>
        /// 订单完成时间开始
        /// </summary>
        public DateTime? ComplateFrom { get; set; }//javascript date within timezone
        /// <summary>
        /// 订单完成时间结束
        /// </summary>
        public DateTime? ComplateTo { get; set; }//javascript date within timezone
    }
}
