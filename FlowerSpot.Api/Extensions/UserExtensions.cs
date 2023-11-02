using System.Security.Claims;

namespace FlowerSpot.Api.Extensions
{
    public static class UserExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
        }
    }
}