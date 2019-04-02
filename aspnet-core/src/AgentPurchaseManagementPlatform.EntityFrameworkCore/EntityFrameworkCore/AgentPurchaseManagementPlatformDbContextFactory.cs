using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AgentPurchaseManagementPlatform.Configuration;
using AgentPurchaseManagementPlatform.Web;

namespace AgentPurchaseManagementPlatform.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AgentPurchaseManagementPlatformDbContextFactory : IDesignTimeDbContextFactory<AgentPurchaseManagementPlatformDbContext>
    {
        public AgentPurchaseManagementPlatformDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AgentPurchaseManagementPlatformDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AgentPurchaseManagementPlatformDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AgentPurchaseManagementPlatformConsts.ConnectionStringName));

            return new AgentPurchaseManagementPlatformDbContext(builder.Options);
        }
    }
}
