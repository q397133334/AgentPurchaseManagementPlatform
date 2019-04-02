using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgentPurchaseManagementPlatform.OrderGoods.Dto
{
    public class OrderMapProfile : Profile
    {
        public OrderMapProfile()
        {
            CreateMap<EditOrderDto,Order>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<DownOrderDto,Order>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
