using System.Net.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTP_C_2
{
    public class WeatherForecast
    {
        public string? cod { get; set; }
        public int? message { get; set; }
        public int? cnt { get; set; }
        public City? city { get; set; }
    }
    public class City
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? country { get; set; }
        public int? population { get; set; }
        public int? timezone { get; set; }
        public int? sunrise { get; set; }
        public int? sunset { get; set; }
    }

    public class Coord
    {
        public double? lat { get; set; }
        public double? lon { get; set; }
    }

    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static string url = "https://api.openweathermap.org/data/2.5/forecast?lat=49.4199579&lon=32.0553984&appid=88a8f189b7528a16f4fda778cb1290ca&cnt=2&units=metric";

        async static Task Main(string[] args)
        {
            await getWeather();

            async Task getWeather()
            {
                Console.WriteLine("Getting JSON...");
                var responseString = await client.GetStringAsync(url);
                Console.WriteLine("Parsing JSON...");
                WeatherForecast? weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(responseString);
                Console.WriteLine($"cod: {weatherForecast?.cod}");
                Console.WriteLine($"city: {weatherForecast?.city?.name}");
                Console.WriteLine($"city population: {weatherForecast?.city?.population}");
            }

            Console.ReadKey();
        }
    }
}