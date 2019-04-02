export class AppConsts {

    static remoteServiceBaseUrl: string;
    static appBaseUrl: string;
    static appBaseHref: string; // returns angular's base-href parameter value if used during the publish

    static defaultLanguage = 'zh-Hans';

    static localeMappings: any = [];



    static readonly userManagement = {
        defaultAdminUserName: 'admin'
    };

    static readonly localization = {
        defaultLocalizationSourceName: 'AgentPurchaseManagementPlatform'
    };

    static readonly authorization = {
        encrptedAuthTokenName: 'enc_auth_token'
    };

    static readonly settingName = {
        USD_CYN: 'App.USD_CYN',
        ChinalogisticsPrice: 'App.ChinalogisticsPrice'
    }

    static readonly permissions = {
        Pages_Tenants: 'Pages.Tenants',
        Pages_Users: 'Pages.Users',
        Pages_Roles: 'Pages.Roles',

        Pages_Orders: 'Pages.Orders',
        Pages_Orders_Add: 'Pages.Orders.Add',
        Pages_Orders_Edit: 'Pages.Orders.Edit',
        Pages_Orders_OtherDesc: 'Pages.Orders.OtherDesc',
        Pages_Orders_Complate: 'Pages.Orders.Complate',
        Pages_Orders_Down: 'Pages.Orders.Down',

        Pages_Setting: 'Pages.Setting',

        /// <summary>
        /// 管理员数据权限
        /// </summary>
        Data_Admin: 'Data.Admin',
        /// <summary>
        /// 淘宝人员数据权限
        /// </summary>
        Data_Taobao: 'Data.Taobao',
        /// <summary>
        /// 海淘人员数据权限
        /// </summary>
        Data_Usa: 'Data.Usa',
    }
}
