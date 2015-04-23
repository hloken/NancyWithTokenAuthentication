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

                var subjectClaim = currentUser.FindFirst("sub");

                string message;
                if (subjectClaim != null)
                {
                    message = string.Format(@"Caller is user: {0}\r\n{1}\r\n", currentUser.CurrentUserId(), CreatePrincipalString(currentUser));
                }
                else
                {
                    message = string.Format("Caller is computer\r\n{0}", CreatePrincipalString(currentUser));
                }

                return Negotiate
                    .WithModel(message)
                    .WithStatusCode(HttpStatusCode.OK);
            };

        }

        private string CreatePrincipalString(ClaimsPrincipal currentUser)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("client_id: {0}\r\n", currentUser.FindFirst("client_id"));
            sb.AppendLine("Claims\n");

            foreach (var claim in currentUser.Claims)
            {
                sb.AppendFormat("Claim: {0}\r\n", claim.ToString());
            }

            return sb.ToString();
        }
    }
}
