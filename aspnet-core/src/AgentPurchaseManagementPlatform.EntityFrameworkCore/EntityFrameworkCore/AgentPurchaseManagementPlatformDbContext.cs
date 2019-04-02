using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AgentPurchaseManagementPlatform.Authorization.Roles;
using AgentPurchaseManagementPlatform.Authorization.Users;
using AgentPurchaseManagementPlatform.MultiTenancy;
using AgentPurchaseManagementPlatform.OrderGoods;
using AgentPurchaseManagementPlatform.Account;
using AgentPurchaseManagementPlatform.Logistics;

namespace AgentPurchaseManagementPlatform.EntityFrameworkCore
{
    public class AgentPurchaseManagementPlatformDbContext : AbpZeroDbContext<Tenant, Role, User, AgentPurchaseManagementPlatformDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<BalanceRecord> BalanceRecords { get; set; }

        public virtual DbSet<Warehouse> Warehouses { get; set; }


        public AgentPurchaseManagementPlatformDbContext(DbContextOptions<AgentPurchaseManagementPlatformDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>(b =>
            {
                b.HasIndex(e => new { e.State });
                b.HasIndex(e => new { e.UsaLogisticsNumber });
            });

            modelBuilder.Entity<BalanceRecord>(b =>
            {
                b.HasIndex(e => new { e.UserId });
            });

        }
    }
}
