using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AgentPurchaseManagementPlatform.Controllers
{
    public abstract class AgentPurchaseManagementPlatformControllerBase: AbpController
    {
        protected AgentPurchaseManagementPlatformControllerBase()
        {
            LocalizationSourceName = AgentPurchaseManagementPlatformConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
