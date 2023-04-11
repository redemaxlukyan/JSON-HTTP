using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTP_C_
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static string url = "https://api.openweathermap.org/data/2.5/forecast?lat=49.4199579&lon=32.0553984&appid=88a8f189b7528a16f4fda778cb1290ca&cnt=2&units=metric";

        async static Task Main(string[] args)
        {
            await getWeather();

            async Task getWeather()
            {
                var responseString = await client.GetStringAsync(url);
                Console.WriteLine(responseString);
            }

            Console.ReadKey();
        }
    }
}

