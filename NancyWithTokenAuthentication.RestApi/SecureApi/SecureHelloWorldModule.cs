using System.Security.Claims;
using System.Text;
using Nancy;
using Nancy.Security;
using NancyWithTokenAuthentication.RestApi.Authentication;

namespace NancyWithTokenAuthentication.RestApi.SecureApi
{
    public class SecureHelloWorldModule : NancyModule
    {
        public SecureHelloWorldModule()
            : base("api/secure/helloworld")
        {
            this.RequiresMSOwinAuthentication();

            Get[""] = parameters =>
            {
                var currentUser = Context.GetMSOwinUser();

                return CreatePrincipalString(currentUser);
            };
        }

        private string CreatePrincipalString(ClaimsPrincipal currentUser)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("userId: {0}\n", currentUser.CurrentUserId());
            sb.AppendLine("Claims\n");

            foreach (var claim in currentUser.Claims)
            {
                sb.AppendFormat("Claim: {0}\r\n", claim.ToString());
            }

            return sb.ToString();
        }
    }
}
