using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using AgentPurchaseManagementPlatform.Authorization.Roles;
using AgentPurchaseManagementPlatform.Authorization.Users;
using AgentPurchaseManagementPlatform.Configuration;
using AgentPurchaseManagementPlatform.Localization;
using AgentPurchaseManagementPlatform.MultiTenancy;
using AgentPurchaseManagementPlatform.Timing;

namespace AgentPurchaseManagementPlatform
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AgentPurchaseManagementPlatformCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            AgentPurchaseManagementPlatformLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = AgentPurchaseManagementPlatformConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AgentPurchaseManagementPlatformCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
