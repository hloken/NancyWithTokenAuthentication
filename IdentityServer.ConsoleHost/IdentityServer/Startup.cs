using Owin;

namespace IdentityServer.ConsoleHost.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServer(IdentityServerSettings.GetIdentityServerOptions());

            app.UseNancy();
        } 
    }
}