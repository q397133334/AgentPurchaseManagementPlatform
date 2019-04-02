using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using AgentPurchaseManagementPlatform.Account;
using System;

namespace AgentPurchaseManagementPlatform.Users.Dto
{
    [AutoMapTo(typeof(BalanceRecord))]
    public class CreateBalanceDto
    {
        [Display(Name = "金额")]
        [Required]
        public decimal Money { get; set; }

        [Display(Name = "说明")]
        public string Desc { get; set; }

        public long UserId { get; set; }
    }

    [AutoMapFrom(typeof(BalanceRecord))]
    public class BalanceDto : EntityDto
    {
        [Display(Name = "金额")]
        [Required]
        public decimal Money { get; set; }

        [Display(Name = "说明")]
        public string Desc { get; set; }

        public long UserId { get; set; }

        public DateTime CreationTime { get; set; }
    }

    [AutoMapTo(typeof(BalanceRecord))]
    [AutoMapFrom(typeof(BalanceRecord))]
    public class EditBalanceDto : EntityDto
    {
        [Display(Name = "金额")]
        [Required]
        public decimal Money { get; set; }

        [Display(Name = "说明")]
        public string Desc { get; set; }

        public long UserId { get; set; }
    }
}
