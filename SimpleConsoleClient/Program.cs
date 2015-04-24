using System;
using System.Net.Http;
using Thinktecture.IdentityModel.Client;

namespace SimpleConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calling RestAPI with machine client token");
            var returnedString = CallRestApiUsingMachineClientToken();
            Console.WriteLine(returnedString);

            Console.WriteLine("\r\nAny key to continue\r\n");
            Console.ReadKey();

            Console.WriteLine("Calling RestAPI with user client token");
            var returnedString2 = CallRestApiUsingUserToken();
            Console.WriteLine(returnedString2);
            
            Console.WriteLine("\r\nAny key to exit\r\n");
            Console.ReadKey();
        }

        private static string CallRestApiUsingUserToken()
        {
            var userTokenResponse = GetUserToken();
            var client = new HttpClient();
            client.SetBearerToken(userTokenResponse.AccessToken);
            var stringAsync = client.GetStringAsync("http://localhost:8080/api/secure/helloworld").Result;
            return stringAsync;
        }

        private static string CallRestApiUsingMachineClientToken()
        {
            var machineTokenResponse = GetMachineToken();
            var client = new HttpClient();
            client.SetBearerToken(machineTokenResponse.AccessToken);
            var stringAsync = client.GetStringAsync("http://localhost:8080/api/secure/helloworld").Result;
            return stringAsync;
        }

        static TokenResponse GetMachineToken()
        {
            Console.WriteLine("Requesting token as machine client");

            var client = new OAuth2Client(
                new Uri("http://localhost:9091/connect/token"),
                "silicon",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            var tokenResponse = client.RequestClientCredentialsAsync("api1").Result;

            Console.WriteLine(tokenResponse != null ? "Success" : "Fail");

            return tokenResponse;
        }

        static TokenResponse GetUserToken()
        {
            Console.WriteLine("Requesting token as machine client");

            var client = new OAuth2Client(
                new Uri("http://localhost:9091/connect/token"),
                "carbon",
                "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            var tokenResponse = client.RequestResourceOwnerPasswordAsync("bob", "secret", "api1").Result;

            Console.WriteLine(tokenResponse != null ? "Success" : "Fail");

            return tokenResponse;
        }
    }
}
