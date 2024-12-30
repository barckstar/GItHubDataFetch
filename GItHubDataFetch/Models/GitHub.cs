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
    }
}
