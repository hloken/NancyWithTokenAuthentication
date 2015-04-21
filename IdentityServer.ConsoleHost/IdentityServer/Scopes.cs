using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace IdentityServer.ConsoleHost.IdentityServer
{
    public class Scopes
    {
        public static List<Scope> Get()
        {
            return new List<Scope>
        {
            new Scope
            {
                Name = "api1"
            }
        };
        }
    }
}