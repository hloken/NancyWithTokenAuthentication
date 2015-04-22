using System.Dynamic;
using System.Linq;
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
            sb.AppendLine("Claims");

            foreach (var claim in currentUser.Claims)
            {
                sb.AppendLine(claim.ToString());
            }

            throw new System.NotImplementedException();
        }
    }
}
