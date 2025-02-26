using GItHubDataFetch.Interfaces;
using GItHubDataFetch.Models;
using Microsoft.AspNetCore.Mvc;

namespace GItHubDataFetch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;


        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRepositories()
        {
            var content = await _gitHubService.GetRepositories();
            return Ok(content);
        }

        [HttpGet("ReposShortFormated")]
        public async Task<ActionResult<GitHub>> ReposShortFormated()
        {
            var reposShort = await _gitHubService.ReposShortFormated();
            return Ok(reposShort);
        }

        [HttpGet("readme")]
        public async Task<IActionResult> GetReadme(string repo)
        {
            var readmeContent = await _gitHubService.GetReadmeContent(repo);
            return Ok(readmeContent);
        }

    }
}

