using FRBSiteMigrator.Models;
using Newtonsoft.Json;
using System.Net;

namespace FRBSiteMigrator
{
    public class WordpressApiService
    {
        static WordpressApiService instance;
        bool initialized = false;
        WebClient client;


        public static WordpressApiService Instance => instance ?? (instance = new WordpressApiService());
        public int MaxQueriesPerSecond { get; set; } = 2;
        public string SiteUrl { get; set; }
        public string ApiUrl => $"https://{SiteUrl}/wp-json";

        private WordpressApiService() { }

        public void Initialize(string siteUrl)
        {
            if (siteUrl.Contains("https://") || siteUrl.Contains("http://"))
            {
                throw new Exception("SiteUrl should not include http://");
            }
            SiteUrl = siteUrl;
            client = new WebClient();
        }

        public void FetchAllPosts(string contentPath)
        {

        }

        public WpPost FetchPost(string id)
        {
            Console.WriteLine($"Fetching post id: {id}");
            string url = $"{ApiUrl}/wp/v2/pages/{id}";
            var content = client.DownloadString(url);
            var wpPost = JsonConvert.DeserializeObject<WpPost>(content);
            return wpPost;
        }

        public List<WpPost> GetPaginatedPosts(int page)
        {
            string url = $"{ApiUrl}/wp/v2/posts?per_page=100&order=asc&orderby=id&page={page}";
            List<WpPost> posts = new List<WpPost>();
            Console.WriteLine($"Fetching posts from page: {page}");
            var content = client.DownloadString(url);
            var parsed = JsonConvert.DeserializeObject<List<WpPost>>(content);
            Console.WriteLine($"Parsed {parsed.Count} pages");
            posts.AddRange(parsed);
            return posts;
        }

        public List<WpPost> GetPaginatedPages(int page)
        {
            string url = $"{ApiUrl}/wp/v2/pages?per_page=100&order=asc&orderby=id&page={page}";
            List<WpPost> posts = new List<WpPost>();
            Console.WriteLine($"Fetching pages from page: {page}");
            var content = client.DownloadString(url);
            var parsed = JsonConvert.DeserializeObject<List<WpPost>>(content);
            Console.WriteLine($"Parsed {parsed.Count} pages");
            posts.AddRange(parsed);
            return posts;
        }

    }
}
