using System.Collections.Generic;
using Abp.Configuration;

namespace AgentPurchaseManagementPlatform.Configuration
{
    public class AppSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(AppSettingNames.UiTheme, "red", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),
                 new SettingDefinition(AppSettingNames.USD_CYN,"6.7426",scopes:SettingScopes.Application,isVisibleToClients:true),
                new SettingDefinition(AppSettingNames.ChinalogisticsPrice,"10",scopes:SettingScopes.Application,isVisibleToClients:true)
            };
        }
    }
}
