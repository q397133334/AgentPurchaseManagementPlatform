using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AgentPurchaseManagementPlatform.Configuration;

namespace AgentPurchaseManagementPlatform.Web.Host.Startup
{
    [DependsOn(
       typeof(AgentPurchaseManagementPlatformWebCoreModule))]
    public class AgentPurchaseManagementPlatformWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AgentPurchaseManagementPlatformWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AgentPurchaseManagementPlatformWebHostModule).GetAssembly());
        }
    }
}
