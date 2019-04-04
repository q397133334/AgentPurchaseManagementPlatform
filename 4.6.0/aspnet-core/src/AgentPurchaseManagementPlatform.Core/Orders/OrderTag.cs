using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentPurchaseManagementPlatform.Configuration;

namespace AgentPurchaseManagementPlatform.Orders
{
    /// <summary>
    /// 订单标签
    /// </summary>
    [Table("OrderTags")]
    public class OrderTag : CreationAuditedEntity<int>, ICreationAudited
    {
        public int TagId { get; set; }

        public int TagName { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
