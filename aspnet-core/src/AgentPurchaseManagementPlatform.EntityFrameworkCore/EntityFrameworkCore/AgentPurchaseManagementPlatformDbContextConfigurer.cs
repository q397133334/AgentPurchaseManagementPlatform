using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AgentPurchaseManagementPlatform.EntityFrameworkCore
{
    public static class AgentPurchaseManagementPlatformDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AgentPurchaseManagementPlatformDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AgentPurchaseManagementPlatformDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
