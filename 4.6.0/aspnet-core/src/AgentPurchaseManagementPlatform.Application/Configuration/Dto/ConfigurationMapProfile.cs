using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentPurchaseManagementPlatform.Configuration.Dto
{
    public class ConfigurationMapProfile : Profile
    {

        public ConfigurationMapProfile()
        {
            #region Receiving
            CreateMap<CreateOrUpdateReceivingDto, Receiving>();
            CreateMap<Receiving, ReceivingDto>();
            #endregion

            #region ReceivingPersion
            CreateMap<CreateOrUpdateReceivingPersionDto, ReceivingPersion>();
            CreateMap<ReceivingPersion, ReceivingPersionDto>();
            #endregion
        }


    }
}
