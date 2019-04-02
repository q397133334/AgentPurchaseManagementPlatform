using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AgentPurchaseManagementPlatform.Authorization.Users;

namespace AgentPurchaseManagementPlatform.Account
{
    [Table("BalanceRecords")]
    public class BalanceRecord : Entity, IHasCreationTime
    {
        public decimal Money { get; set; }

        public string Desc { get; set; }

        public long UserId { get; set; }

        public DateTime CreationTime { get; set; }

        public virtual User User { get; set; }
    }
}
