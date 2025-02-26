using GItHubDataFetch.Interfaces;
using GItHubDataFetch.Models;
using Newtonsoft.Json;
using System.Text;

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
                    FullName = repo.FullName,
                    Topics = repo.Topics

                }).ToList();

        }

        // Nuevo método para obtener el README.md de un repositorio específico
        public async Task<string> GetReadmeContent(string repo)
        {
            var client = _httpClientFactory.CreateClient("GitHubClient");
            var response = await client.GetAsync($"repos/barckstar/{repo}/contents/README.md");
            response.EnsureSuccessStatusCode();

            // Leer la respuesta como un objeto JSON
            var contentResponse = await response.Content.ReadAsStringAsync();
            var readmeObject = JsonConvert.DeserializeObject<GitHubReadmeResponse>(contentResponse);

            if (readmeObject == null || string.IsNullOrEmpty(readmeObject.Content))
            {
                return "README.md not found or empty.";
            }

            // Decodificar el contenido Base64
            var readmeContent = Encoding.UTF8.GetString(Convert.FromBase64String(readmeObject.Content));
            return readmeContent;
        }
    }
}

