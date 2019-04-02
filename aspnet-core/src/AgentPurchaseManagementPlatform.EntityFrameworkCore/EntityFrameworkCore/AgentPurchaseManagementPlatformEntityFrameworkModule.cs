using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using AgentPurchaseManagementPlatform.EntityFrameworkCore.Seed;

namespace AgentPurchaseManagementPlatform.EntityFrameworkCore
{
    [DependsOn(
        typeof(AgentPurchaseManagementPlatformCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class AgentPurchaseManagementPlatformEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<AgentPurchaseManagementPlatformDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        AgentPurchaseManagementPlatformDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        AgentPurchaseManagementPlatformDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AgentPurchaseManagementPlatformEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
