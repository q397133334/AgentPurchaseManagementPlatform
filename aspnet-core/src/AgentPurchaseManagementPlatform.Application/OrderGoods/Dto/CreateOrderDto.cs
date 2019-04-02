using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgentPurchaseManagementPlatform.OrderGoods.Dto
{
    [AutoMapTo(typeof(Order))]
    public class CreateOrderDto
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
        /// 产品价格
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// 实际销售价格
        /// </summary>
        [Required]
        public decimal? TrueSalePrice { get; set; }

        [MaxLength(4000)]
        /// <summary>
        /// 客户要求
        /// </summary>
        public string CustomerDesc { get; set; }

        [MaxLength(4000)]
        /// <summary>
        /// 客户地址（收件）
        /// </summary>
        public string CustomerAddress { get; set; }

        [MaxLength(4000)]
        /// <summary>
        /// 产品图片
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// 其他
        /// </summary>
        public string OtherDesc { get; set; }
    }
}
