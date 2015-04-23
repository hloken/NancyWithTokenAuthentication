using System;
using System.Net.Http;
using Thinktecture.IdentityModel.Client;

namespace SimpleConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var machineTokenResponse = GetMachineToken();
            Console.WriteLine("Calling RestAPI with machine client token");
            var client = new HttpClient();
            client.SetBearerToken(machineTokenResponse.AccessToken);
            var stringAsync = client.GetStringAsync("http://localhost:8080/api/secure/helloworld").Result;
            Console.WriteLine(stringAsync);

            var userTokenResponse = GetUserToken();
            Console.WriteLine("Calling RestAPI with user client token");
            var client2 = new HttpClient();
            client2.SetBearerToken(userTokenResponse.AccessToken);
            Console.WriteLine(client2.GetStringAsync("http://localhost:8080/api/secure/helloworld").Result);
            
            Console.WriteLine("\r\nAny key to exit\r\n");
            Console.ReadKey();
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
                new Uri("https://localhost:9091/connect/token"),
                "carbon",
                "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            var tokenResponse = client.RequestResourceOwnerPasswordAsync("bob", "secret", "api1").Result;

            Console.WriteLine(tokenResponse != null ? "Success" : "Fail");

            return tokenResponse;
        }
    }
}
