using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentPurchaseManagementPlatform.Configuration
{
    /// <summary>
    /// 标签
    /// </summary>
    [Table("Tags")]
    public class Tag : Entity
    {
        public string Name { get; set; }
    }
}
