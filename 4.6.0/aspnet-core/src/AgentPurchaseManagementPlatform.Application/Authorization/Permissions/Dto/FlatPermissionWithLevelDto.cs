﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentPurchaseManagementPlatform.Authorization.Permissions.Dto
{
    public class FlatPermissionWithLevelDto : FlatPermissionDto
    {
        public int Level { get; set; }
    }
}
