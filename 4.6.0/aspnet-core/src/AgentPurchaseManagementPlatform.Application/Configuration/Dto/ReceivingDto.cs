using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentPurchaseManagementPlatform.Configuration;

namespace AgentPurchaseManagementPlatform.Configuration.Dto
{
    [AutoMapFrom(typeof(Receiving))]
    public class ReceivingDto : EntityDto
    {
        public string Address { get; set; }
    }
}
