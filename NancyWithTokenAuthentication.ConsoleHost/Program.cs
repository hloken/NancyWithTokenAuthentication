using System;
using Microsoft.Owin.Hosting;
using NancyWithTokenAuthentication.RestApi.Bootstrap;

namespace NancyWithTokenAuthentication.RestApi.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            const string restApiUrl = "http://localhost:8080";

            using (WebApp.Start<Startup>(restApiUrl))
            {
                Console.WriteLine("The rest API is running on " + restApiUrl);
                Console.WriteLine("Press any [Enter] to close the host.");
                Console.ReadLine();
            }
        }
    }
}
