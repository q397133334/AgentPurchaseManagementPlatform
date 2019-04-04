﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentPurchaseManagementPlatform.Orders
{
    [Table("Orders")]
    public class Order : FullAuditedEntity, IFullAudited, ICreationAudited
    {

    }
}
