using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AgentPurchaseManagementPlatform.Configuration.Dto;

namespace AgentPurchaseManagementPlatform.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AgentPurchaseManagementPlatformAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }

        public async Task UpdateSettingChinalogisticsPrice(decimal value)
        {
            await SettingManager.ChangeSettingForApplicationAsync(AppSettingNames.ChinalogisticsPrice, value.ToString());
        }

        public async Task UpdateSettingUSD_CYN(decimal value)
        {
            await SettingManager.ChangeSettingForApplicationAsync(AppSettingNames.USD_CYN, value.ToString());
        }
    }
}
