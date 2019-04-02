using System.Threading.Tasks;
using AgentPurchaseManagementPlatform.Configuration.Dto;

namespace AgentPurchaseManagementPlatform.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);

        /// <summary>
        /// 修改人民币美元汇率
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task UpdateSettingUSD_CYN(decimal value);

        Task UpdateSettingChinalogisticsPrice(decimal value);
    }
}
