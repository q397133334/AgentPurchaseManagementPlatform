using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace AgentPurchaseManagementPlatform.Authorization
{
    public class AgentPurchaseManagementPlatformAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            var order = context.CreatePermission(PermissionNames.Pages_Orders, L("Orders"));
            order.CreateChildPermission(PermissionNames.Pages_Orders_Add, L("OrdersAdd"));
            order.CreateChildPermission(PermissionNames.Pages_Orders_Complate, L("OrderComplate"));
            order.CreateChildPermission(PermissionNames.Pages_Orders_Edit, L("OrderEdit"));
            order.CreateChildPermission(PermissionNames.Pages_Orders_Down, L("OrderDwon"));
            order.CreateChildPermission(PermissionNames.Pages_Orders_OtherDesc, L("OrderOtherDesc"));

            context.CreatePermission(PermissionNames.Pages_Setting, L("系统设置"));

            
            context.CreatePermission(PermissionNames.Data_Admin, L("DataAdmin"));
            context.CreatePermission(PermissionNames.Data_Taobao, L("DataTaobao"));
            context.CreatePermission(PermissionNames.Data_Usa, L("DataUsa"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AgentPurchaseManagementPlatformConsts.LocalizationSourceName);
        }
    }
}
