using System;
using System.Net.Http;
using Thinktecture.IdentityModel.Client;

namespace SimpleConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenResponse = GetToken();
            CallApi(tokenResponse);
        }

        static TokenResponse GetToken()
        {
            var client = new OAuth2Client(
                new Uri("http://localhost:9091/connect/token"),
                "silicon",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("api1").Result;
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStringAsync("http://localhost:8080/api/secure/helloworld").Result);

            Console.WriteLine("\r\nAny key to exit\r\n");
            Console.ReadKey();
        }


    }
}
