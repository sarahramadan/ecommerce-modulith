using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Auth
{
    public class Authorization: IAuthorization
    {
        public string GetCurrentUserId()
        {
            // Try to get user ID from HttpContext if available
            var httpContext = System.Threading.Thread.CurrentPrincipal as System.Security.Claims.ClaimsPrincipal;
            if (httpContext != null)
            {
                var userIdClaim = httpContext.Claims.FirstOrDefault(c => c.Type == "sub" || c.Type == "userid" || c.Type == System.Security.Claims.ClaimTypes.NameIdentifier);
                if (userIdClaim != null)
                {
                    return userIdClaim.Value;
                }
            }

            // Fallback: use Thread.CurrentPrincipal.Identity.Name
            var principal = System.Threading.Thread.CurrentPrincipal;
            if (principal?.Identity?.IsAuthenticated == true)
            {
                return principal.Identity.Name ?? "Unknown";
            }

            // If no user context is available
            return "System";
        }
    }
}
