using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentPurchaseManagementPlatform.Configuration
{

    [Table("Receivings")]
    public class Receiving : Entity
    {
        [Required]
        [MaxLength(1000)]
        public string Address { get; set; }

        public virtual ICollection<ReceivingPersion> ReceivingPersions { get; set; }
    }

    [Table("ReceivingPersions")]
    public class ReceivingPersion : Entity
    {
        public int ReceivingId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual Receiving Receiving { get; set; }
    }
}
