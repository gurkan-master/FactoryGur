using Microsoft.AspNetCore.Mvc.RazorPages;
using Refit;

namespace FactoryGur.Models
{
    public class RefitModel : PageModel
    {
        private readonly IGitHubClient _gitHubClient;
        public RefitModel(IGitHubClient gitHubClient) =>
            _gitHubClient = gitHubClient;

        public IEnumerable<GitHubBranch>? GitHubBranches { get; set; }

        public async Task OnGet()
        {
            try
            {
                GitHubBranches = await _gitHubClient.GetAspNetCoreDocsBranchesAsync();
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
