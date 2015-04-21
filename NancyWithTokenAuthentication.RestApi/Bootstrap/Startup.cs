using Owin;
using Thinktecture.IdentityServer.AccessTokenValidation;

namespace NancyWithTokenAuthentication.RestApi.Bootstrap
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Token Verification
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:9091",
                RequiredScopes = new[] { "api1" }
            });

            app.UseNancy();
        }
    }
}