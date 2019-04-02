using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AgentPurchaseManagementPlatform.Localization
{
    public static class AgentPurchaseManagementPlatformLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AgentPurchaseManagementPlatformConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AgentPurchaseManagementPlatformLocalizationConfigurer).GetAssembly(),
                        "AgentPurchaseManagementPlatform.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
