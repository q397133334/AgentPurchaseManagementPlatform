using Abp.AutoMapper;
using AgentPurchaseManagementPlatform.Authentication.External;

namespace AgentPurchaseManagementPlatform.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
