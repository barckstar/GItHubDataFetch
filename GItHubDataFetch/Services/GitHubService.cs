using GItHubDataFetch.Interfaces;
using GItHubDataFetch.Models;
using Newtonsoft.Json;

namespace GItHubDataFetch.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GitHubService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetRepositories()
        {
            var client = _httpClientFactory.CreateClient("GitHubClient");
            var response = await client.GetAsync("users/barckstar/repos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<GitHub>> ReposShortFormated()
        {
            var gitData = await GetRepositories();
            var originalData = JsonConvert.DeserializeObject<List<GitHub>>(gitData);
            if(originalData == null)
            {
                return new List<GitHub>();
            }
            return originalData!
                .Select(repo => new GitHub
                {
                    Id = repo.Id,
                    Name = repo.Name,
                    Description = repo.Description ?? "No description",
                    HtmlUrl = repo.HtmlUrl,
                    FullName = repo.FullName
                }).ToList();

        }
    }
}
