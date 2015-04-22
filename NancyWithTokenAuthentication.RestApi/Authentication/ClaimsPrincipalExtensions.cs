using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace NancyWithTokenAuthentication.RestApi.Authentication
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid CurrentUserId(this ClaimsPrincipal principal)
        {
            var subject = principal.Claims.GetClaimValue("sub");
            Guid userId;

            if (!Guid.TryParse(subject, out userId))
                throw new ApplicationException(String.Format("Invalid userid {0}", subject));

            return userId;
        }

        public static string GetClaimValue(this IEnumerable<Claim> claims, string type)
        {
            var claim = claims.FirstOrDefault(x => x.Type == type);

            return (claim != null ? claim.Value : null);
        }
    }
}