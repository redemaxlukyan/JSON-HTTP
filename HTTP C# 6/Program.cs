using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace HTTP_C__6
{
    public class YoutubeMain
    {
        public string? kind { get; set; }
        public IList<YoutubeChannelItems?> items { get; set; }
        public YoutubePageInfo? pageInfo { get; set; }
    }

    public class YoutubeChannelItems
    {
        public string? kind { get; set; }
        public YoutubeItemsSnippet? snippet { get; set; }
    }

    public class YoutubeItemsSnippet
    {
        public string? publishedAt { get; set; }
        public string? title { get; set; }
    }

    public class YoutubePageInfo
    {
        public int? totalResults { get; set; }
    }


    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static string url = "https://youtube.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=25&playlistId=PLSN6qXliOioz5lnckfofNcLJ3CnZJvEJO&key=AIzaSyAjUcFFlZW2NIo6vZHITLJX5hI-uRi_Vvc";

        async static Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            await getYoutubeInfo();

            async Task getYoutubeInfo()
            {
                var responseString = await client.GetStringAsync(url);
                YoutubeMain? youtubeMain = JsonSerializer.Deserialize<YoutubeMain>(responseString);
                Console.WriteLine($"Kind main: {youtubeMain?.kind}");
                Console.WriteLine($"Total videos in playlist: {youtubeMain?.items?.Count}");
                Console.WriteLine();
                foreach (var youtubeItem in youtubeMain?.items)
                {
                    Console.WriteLine($"Title: {youtubeItem?.snippet?.title}");
                    Console.WriteLine($"Published at: {youtubeItem?.snippet?.publishedAt}");
                }

            }

            Console.ReadKey();
        }
    }
}
