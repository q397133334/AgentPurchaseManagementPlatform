using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgentPurchaseManagementPlatform.OrderGoods.Dto
{
    public class DownOrderDto : EntityDto
    {
        ///// <summary>
        ///// 网站到货时间
        ///// </summary>
        //public DateTime ArrivalDateTime { get; set; }


        [Display(Name = "美国物流单号")]
        /// <summary>
        /// 美国物流单号
        /// </summary>
        public string UsaLogisticsNumber { get; set; }


        [Display(Name = "实际订购价格")]
        /// <summary>
        /// 实际订购价格
        /// </summary>
        public decimal? TrueBuyPrice { get; set; }

        [Display(Name = "转运单号")]
        /// <summary>
        /// 转运单号
        /// </summary>
        public string TransportNumber { get; set; }

        [Display(Name = "转运运费")]
        /// <summary>
        /// 转运运费
        /// </summary>
        public decimal? TransportPrice { get; set; }

        [Display(Name = "未订购原因")]
        /// <summary>
        /// 未订购原因
        /// </summary>
        public string NotBuyDesc { get; set; }

        [Display(Name = "订单状态")]
        public OrderType State { get; set; }
    }
}
