using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace HTTP_C__5
{
    class IpInfo
    {
        public string? ip { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? org { get; set; }
        public string? postal { get; set; }
        public string? timezone { get; set; }
    }

    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static string url = "https://ipinfo.io/185.3.148.163/geo";
        async static Task Main(string[] args)
        {
            await getWeather();

            async Task getWeather()
            {
                var responseString = await client.GetStringAsync(url);
                IpInfo? IpInfo = JsonSerializer.Deserialize<IpInfo>(responseString);
                Console.WriteLine($"Your IP: {IpInfo?.ip}");
                Console.WriteLine($"City of your location: {IpInfo?.city}");
                Console.WriteLine($"Internet provider: {IpInfo?.org}");
                Console.WriteLine($"Timezone: {IpInfo?.timezone}");
            }

            Console.ReadKey();
        }
    }
}
