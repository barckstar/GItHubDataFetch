using GItHubDataFetch.Models;

namespace GItHubDataFetch.Interfaces
{
    public interface IGitHubService
    {
        Task<string> GetRepositories();
        Task<List<GitHub>> ReposShortFormated();
        Task<string> GetReadmeContent(string repo);
    }
}
