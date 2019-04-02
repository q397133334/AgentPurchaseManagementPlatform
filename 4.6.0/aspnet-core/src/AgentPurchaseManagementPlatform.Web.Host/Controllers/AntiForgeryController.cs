using Microsoft.AspNetCore.Antiforgery;
using AgentPurchaseManagementPlatform.Controllers;

namespace AgentPurchaseManagementPlatform.Web.Host.Controllers
{
    public class AntiForgeryController : AgentPurchaseManagementPlatformControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
