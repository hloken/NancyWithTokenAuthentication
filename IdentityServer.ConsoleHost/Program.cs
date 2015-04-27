using System;
using Microsoft.Owin.Hosting;

namespace IdentityServer.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            const string identityServerUrl = "http://localhost:9091";

            using (WebApp.Start<IdentityServer.Startup>(identityServerUrl))
            {
                Console.WriteLine("The IdentityServer3 is running on " + identityServerUrl);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }
}
