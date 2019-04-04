using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;

namespace AgentPurchaseManagementPlatform.Configuration.Dto
{
    [AutoMapFrom(typeof(ReceivingPersion))]
    public class ReceivingPersionDto : EntityDto
    {

        public int ReceivingId { get; set; }

        public string Name { get; set; }
    }
}
