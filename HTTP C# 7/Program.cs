using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace HTTP_C__7
{
    public class YoutubeMain
    {
        public IList<YoutubeChannelItems>? items { get; set; }
    }

    public class YoutubeChannelItems
    {
        public YoutubeChannelStats? statistics { get; set; }
    }

    public class YoutubeChannelStats
    {
        public string? viewCount { get; set; }
        public string? likeCount { get; set; }
    }
    internal class Program
    {
        private static int _viewCount;
        private static int _likeCount;
        private static int _viewCountTotal;
        private static int _likeCountTotal;
        private static readonly HttpClient client = new HttpClient();
        private static string url = "https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyAjUcFFlZW2NIo6vZHITLJX5hI-uRi_Vvc&id=sqVMhqSOSzo";
        public static string[] urls = { 
            "https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyAjUcFFlZW2NIo6vZHITLJX5hI-uRi_Vvc&id=sqVMhqSOSzo",
            "https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyAjUcFFlZW2NIo6vZHITLJX5hI-uRi_Vvc&id=5Y-SGvb3e0Y",
            "https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyAjUcFFlZW2NIo6vZHITLJX5hI-uRi_Vvc&id=eS-hnV-KwaQ",
            "https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyAjUcFFlZW2NIo6vZHITLJX5hI-uRi_Vvc&id=9vPUGpJIzek",
            "https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyAjUcFFlZW2NIo6vZHITLJX5hI-uRi_Vvc&id=_3sxgcVQx9o",
            "https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&key=AIzaSyAjUcFFlZW2NIo6vZHITLJX5hI-uRi_Vvc&id=r0Wca9JCDeA"
        };

        public static string[] names = { "Eduard", "Kyryl", "Oleksiy", "Rostyslav", "Aris", "Artur"};

        async static Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            await getYoutubeInfo();

            async Task getYoutubeInfo()
            {
                for (int i = 0; i < urls.Length; i++)
                {
                    string responseString = await client.GetStringAsync(urls[i]);
                    YoutubeMain? youtubeMain = JsonSerializer.Deserialize<YoutubeMain>(responseString);
                    foreach (var youtubeItem in youtubeMain?.items)
                    {
                        Console.WriteLine($"Video with {names[i]} view count: {_viewCount = int.Parse(youtubeItem?.statistics?.viewCount)}");
                        Console.WriteLine($"Video with {names[i]} like count: {_likeCount = int.Parse(youtubeItem?.statistics?.likeCount)}");
                        _viewCountTotal += _viewCount;
                        _likeCountTotal += _likeCount;
                    }
                }

                Console.WriteLine($"\nView count total: {_viewCountTotal}");
                Console.WriteLine($"Like count total: {_likeCountTotal}");
            }

            Console.ReadKey();
        }
    }
}
