using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AgentPurchaseManagementPlatform.Authorization.Roles;
using AgentPurchaseManagementPlatform.Authorization.Users;
using AgentPurchaseManagementPlatform.MultiTenancy;

namespace AgentPurchaseManagementPlatform.EntityFrameworkCore
{
    public class AgentPurchaseManagementPlatformDbContext : AbpZeroDbContext<Tenant, Role, User, AgentPurchaseManagementPlatformDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AgentPurchaseManagementPlatformDbContext(DbContextOptions<AgentPurchaseManagementPlatformDbContext> options)
            : base(options)
        {
        }
    }
}
