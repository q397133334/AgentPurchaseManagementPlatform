using System.Collections.Generic;

namespace AgentPurchaseManagementPlatform.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
