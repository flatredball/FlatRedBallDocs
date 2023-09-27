using Newtonsoft.Json;

namespace FRBSiteMigrator.Models
{
    /// <summary>
    /// This class represents the storage format for the main
    /// WordPress storage format. Note that pages, media, posts,
    /// and most other data types in WordPress are all stored
    /// in this format, despite the model name.
    /// </summary>
    public class WpPost
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date_gmt")]
        public DateTime CreatedGmt { get; set; }

        [JsonProperty("modified_gmt")]
        public DateTime ModifiedGmt { get; set; }
        
        [JsonProperty("guid")]
        public RenderedContent Guid { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("title")]
        public RenderedContent Title { get; set; }

        [JsonProperty("parent")]
        public int ParentId { get; set; }

        [JsonProperty("author")]
        public int AuthorId { get; set; }

        [CsvHelper.Configuration.Attributes.Ignore()]
        public RenderedContent Content { get; set; }

        public bool IsProcessed { get; set; } = false;
    }

    public class RenderedContent
    {
        [JsonProperty("rendered")]
        public string Rendered { get; set; }

        public override string ToString()
        {
            return Rendered;
        }
    }
}
