using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace AgentPurchaseManagementPlatform.OrderGoods
{
    [Table("Orders")]
    public class Order : FullAuditedEntity<int>, IFullAudited, IMayHaveTenant
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
        public decimal ChinalogisticsPrice { get; set; } = 10;

        /// <summary>
        /// 未订购原因
        /// </summary>
        public string NotBuyDesc { get; set; }

        /// <summary>
        /// 其他说明
        /// </summary>
        public string OtherDesc { get; set; }

        /// <summary>
        /// 计算利润时的汇率
        /// </summary>
        public decimal? Huilv { get; set; }

        /// <summary>
        /// 利润
        /// </summary>
        public decimal? Lirun { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderType State { get; set; }
        public int? TenantId { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public int? WarehouseId { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public int? WarehouseConsignee { get; set; }
        /// <summary>
        /// 收货人名称
        /// </summary>
        public string WarehouseConsigneeName { get; set; }
    }

    public enum OrderType
    {
        等待订购,
        已经订购,
        美国出单,
        转运出单,
        国内发货,
        交易成功,
        交易失败
    }
}
