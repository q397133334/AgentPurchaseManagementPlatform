﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgentPurchaseManagementPlatform.OrderGoods.Dto
{
    [AutoMapTo(typeof(Order))]
    [AutoMapFrom(typeof(Order))]
    public class EditOrderDto : EntityDto
    {

        /// <summary>
        /// 网站到货时间
        /// </summary>
        public DateTime ArrivalDateTime { get; set; }

        /// <summary>
        /// 产品价格
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// 美国物流单号
        /// </summary>
        public string UsaLogisticsNumber { get; set; }

        /// <summary>
        /// 实际订购价格
        /// </summary>
        public decimal? TrueBuyPrice { get; set; }

        /// <summary>
        /// 实际销售价格
        /// </summary>
        public decimal? TrueSalePrice { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        public long AccountId { get; set; }

        /// <summary>
        /// 转运单号
        /// </summary>
        public string TransportNumber { get; set; }

        /// <summary>
        /// 转运运费
        /// </summary>
        public decimal? TransportPrice { get; set; }


        /// <summary>
        /// 国内单号
        /// </summary>
        public string ChinaLogisticsNumber { get; set; }

        /// <summary>
        /// 国内运费
        /// </summary>
        public decimal? ChinalogisticsPrice { get; set; }

        /// <summary>
        /// 未订购原因
        /// </summary>
        public string NotBuyDesc { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderType State { get; set; }
    }
}
