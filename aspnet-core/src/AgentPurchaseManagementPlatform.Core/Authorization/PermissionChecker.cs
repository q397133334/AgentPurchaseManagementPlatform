using Abp.Authorization;
using AgentPurchaseManagementPlatform.Authorization.Roles;
using AgentPurchaseManagementPlatform.Authorization.Users;

namespace AgentPurchaseManagementPlatform.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
