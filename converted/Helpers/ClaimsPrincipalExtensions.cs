using System.Security.Claims;

namespace Bookstore.Web.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetSub(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static string GetSub(this ClaimsIdentity identity)
        {
            return identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}