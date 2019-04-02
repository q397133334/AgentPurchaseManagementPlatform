﻿using AgentPurchaseManagementPlatform.Authorization.Permissions.Dto;
using System.Collections.Generic;

namespace AgentPurchaseManagementPlatform.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}