using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AgentPurchaseManagementPlatform.Authorization.Roles;
using AgentPurchaseManagementPlatform.Authorization.Users;
using AgentPurchaseManagementPlatform.MultiTenancy;
using AgentPurchaseManagementPlatform.Configuration;

namespace AgentPurchaseManagementPlatform.EntityFrameworkCore
{
    public class AgentPurchaseManagementPlatformDbContext : AbpZeroDbContext<Tenant, Role, User, AgentPurchaseManagementPlatformDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Receiving> Receivings { get; set; }

        public DbSet<ReceivingPersion> ReceivingPersions { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public AgentPurchaseManagementPlatformDbContext(DbContextOptions<AgentPurchaseManagementPlatformDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceivingPersion>().HasIndex(b => b.Name);
            modelBuilder.Entity<Receiving>().HasIndex(b => b.Address);
            modelBuilder.Entity<Tag>().HasIndex(b => b.Name);

            base.OnModelCreating(modelBuilder);
        }
    }
}
