using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Core.Services.InMemory;

namespace IdentityServer.ConsoleHost.IdentityServer
{
    public class IdentityServerSettings
    {
        public static IdentityServerOptions GetIdentityServerOptions()
        {
            var factory = InMemoryFactory.Create(
                scopes: Scopes.Get(),
                clients: Clients.Get(),
                users: new List<InMemoryUser>()
                );

            var options = new IdentityServerOptions
            {
                Factory = factory,
                RequireSsl = false
            };
            return options;
        }
    }
}