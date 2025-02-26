using Newtonsoft.Json;

namespace GItHubDataFetch.Models
{
    public class GitHub
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("topics")]
        public List<string> Topics { get; set; }
    }
    public class GitHubReadmeResponse
    {
        [JsonProperty("content")]
        public string Content { get; set; } = string.Empty;

        [JsonProperty("encoding")]
        public string Encoding { get; set; } = string.Empty;
    }
}
