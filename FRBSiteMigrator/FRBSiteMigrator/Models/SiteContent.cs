
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace FRBSiteMigrator.Models
{
    public enum ProcessingStatus
    {
        Unknown = 0,
        FetchedRaw = 1,
    }

    public class Site
    {
        public string SiteUrl { get; set; }
        public List<SiteContent> Pages { get; set; } = new List<SiteContent>();
        public List<SiteContent> Media { get; set; } = new List<SiteContent>();
        public List<SiteContent> Posts { get; set; } = new List<SiteContent>();
        public List<string> BadMediaPaths { get; set; } = new List<string>();
        public List<string> FailedPageConversions { get; set; } = new List<string>();

        [JsonIgnore]
        public List<SiteContent> AllContent =>
            new List<SiteContent>()
                    .Concat(Media)
                    .Concat(Posts)
                    .Concat(Pages)
                    .ToList();

        [JsonIgnore]
        public int PageCount => Pages.Count;

        [JsonIgnore]
        public int MediaCount => Media.Count;

        [JsonIgnore]
        public int PostCount => Posts.Count;

        public void AddContent(SiteContent content)
        {
            if(content.SiteStatus == "publish" ||
                content.SiteStatus == "inherit")
            {
                if(content.Type == "attachment")
                {
                    Media.Add(content);
                }
                else if(content.Type == "page")
                {
                    Pages.Add(content);
                }
                else if(content.Type == "post")
                {
                    Posts.Add(content);
                }
            }
        }
    }

    public class SiteContent
    {
        // wordpress content fields
        public int Id { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public string Guid { get; set; }
        public int ParentId { get; set; }
        public string SiteStatus { get; set; }
        public string Title { get; set; }
        public string RawContent { get; set; }

        public string ProcessedContent { get; set; }
        
        
        // processing fields
        public string ProcessedPath { get; set; }

        [JsonIgnore]
        public List<string> Links
        {
            get
            {
                List<string> links = new List<string>();
                Regex anchors = new Regex("<[Aa][^>]+href=[\"']([^\"']+)[\"'][^>]*>");
                foreach (Match match in anchors.Matches(RawContent))
                {
                    var href = match.Groups[1].Value;
                    if(!links.Contains(href))
                    {
                        links.Add(href);
                    }
                    
                }
                return links;
            }
        }

        [JsonIgnore]
        public List<string> Images
        {
            get
            {
                List<string> images = new List<string>();
                Regex img = new Regex("<[Ii][Mm][Gg][^>]+src=[\"']([^\"'>]+)[\"'][^>]*>");
                foreach (Match match in img.Matches(RawContent))
                {
                    var src = match.Groups[1].Value;
                    if(!images.Contains(src))
                    {
                        images.Add(src);
                    }
                }
                return images;
            }
        }
    }
}
