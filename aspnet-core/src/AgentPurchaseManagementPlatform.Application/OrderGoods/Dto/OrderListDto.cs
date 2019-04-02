using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgentPurchaseManagementPlatform.OrderGoods.Dto
{

    public class OrderListDto : EntityDto
    {
        /// <summary>
        /// 国内下单时间
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime ChinaDateTime { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [Required]
        [MaxLength(4000)]
        public string ProductName { get; set; }

        /// <summary>
        /// 产品网站链接
        /// </summary>
        [Required]
        [MaxLength(4000)]
        public string ProductUrl { get; set; }

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
        /// 产品图片
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 客户要求
        /// </summary>
        public string CustomerDesc { get; set; }

        /// <summary>
        /// 客户地址（收件）
        /// </summary>
        public string CustomerAddress { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// 店铺
        /// </summary>
        public string TaobaoShop { get; set; }

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
        public decimal ChinalogisticsPrice { get; set; }

        /// <summary>
        /// 未订购原因
        /// </summary>
        public string NotBuyDesc { get; set; }

        public string OtherDesc { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderType State { get; set; }
        public int? TenantId { get; set; }
    }
}
