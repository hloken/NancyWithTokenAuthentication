using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Nancy;
using Owin;

namespace NancyWithTokenAuthentication.Web
{
    [assembly: OwinStartup(typeof(Startup))]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileSystem = new PhysicalFileSystem(@"App"),
            //    RequestPath = new PathString("/App"),
            //    ServeUnknownFileTypes = true
            //});
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileSystem = new PhysicalFileSystem(@"bower_components"),
            //    RequestPath = new PathString("/bower_components")
            //});

            app.UseStageMarker(PipelineStage.MapHandler);

            StaticConfiguration.DisableErrorTraces = false;

            //Token Verification
            //app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            //{
            //    Authority = "http://localhost:9091",
            //    RequiredScopes = new[] { "api1" }
            //});

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "http://localhost:9091/identity",
                ClientId = "mvc",
                RedirectUri = "http://localhost:9091/",
                ResponseType = "id_token",

                SignInAsAuthenticationType = "Cookies"
            });
            //app.UseNancy();
        }
    }
}