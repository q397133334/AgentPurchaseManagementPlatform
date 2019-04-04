using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;

namespace AgentPurchaseManagementPlatform.Configuration.Dto
{
    [AutoMapTo(typeof(ReceivingPersion))]
    public class CreateOrUpdateReceivingPersionDto : ReceivingPersionDto
    {
    }


}
