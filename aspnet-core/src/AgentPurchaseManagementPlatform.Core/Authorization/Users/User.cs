using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using System.Collections;
using AgentPurchaseManagementPlatform.Account;
using System.Collections.Generic;

namespace AgentPurchaseManagementPlatform.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public User() : base()
        {
            BalanceRecords = new List<BalanceRecord>();
        }

        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal? Balance { get; set; } = 0;

        public virtual List<BalanceRecord> BalanceRecords { get; set; }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
