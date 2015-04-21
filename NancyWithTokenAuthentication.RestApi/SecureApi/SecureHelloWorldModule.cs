using Nancy;
using Nancy.Security;

namespace NancyWithTokenAuthentication.RestApi.SecureApi
{
    public class SecureHelloWorldModule : NancyModule
    {
        public SecureHelloWorldModule()
            : base("api/secure/helloworld")
        {
            this.RequiresMSOwinAuthentication();

            Get[""] = parameters => "Very secure Hello World!";
        }
    }
}
