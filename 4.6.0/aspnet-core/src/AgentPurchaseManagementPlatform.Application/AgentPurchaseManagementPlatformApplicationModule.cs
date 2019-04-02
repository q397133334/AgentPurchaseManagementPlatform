using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AgentPurchaseManagementPlatform.Authorization;

namespace AgentPurchaseManagementPlatform
{
    [DependsOn(
        typeof(AgentPurchaseManagementPlatformCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AgentPurchaseManagementPlatformApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AgentPurchaseManagementPlatformAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AgentPurchaseManagementPlatformApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
