using Abp.MultiTenancy;
using AgentPurchaseManagementPlatform.Authorization.Users;

namespace AgentPurchaseManagementPlatform.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
