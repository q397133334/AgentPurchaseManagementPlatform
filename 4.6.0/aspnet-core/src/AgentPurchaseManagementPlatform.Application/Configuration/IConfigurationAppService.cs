using System.Threading.Tasks;
using AgentPurchaseManagementPlatform.Configuration.Dto;

namespace AgentPurchaseManagementPlatform.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
