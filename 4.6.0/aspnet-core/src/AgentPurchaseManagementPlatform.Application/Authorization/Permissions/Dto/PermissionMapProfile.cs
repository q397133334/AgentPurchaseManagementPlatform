using Abp.Authorization;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentPurchaseManagementPlatform.Authorization.Permissions.Dto
{
    public class PermissionMapProfile : Profile
    {
        public PermissionMapProfile()
        {
            CreateMap<Permission, FlatPermissionDto>();
            CreateMap<Permission, FlatPermissionWithLevelDto>();
        }
    }
}
