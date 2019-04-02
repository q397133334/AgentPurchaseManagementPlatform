using System.ComponentModel.DataAnnotations;

namespace AgentPurchaseManagementPlatform.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}