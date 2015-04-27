using Owin;
using Thinktecture.IdentityServer.Core.Configuration;

namespace IdentityServer.ConsoleHost.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServer(new IdentityServerOptions
            {
                RequireSsl = false,
                Factory = InMemoryFactory.Create(
                    scopes: Scopes.Get(),
                    clients: Clients.Get(),
                    users: Users.Get()
                    )
            });

            //app.UseNancy();
        } 
    }
}