using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactoryGur.Models
{
    public class TypedClientModel : PageModel
    {
        private readonly GitHubService _gitHubService;

        public TypedClientModel(GitHubService gitHubService) =>
            _gitHubService = gitHubService;

        public IEnumerable<GitHubBranch>? GitHubBranches { get; set; }

        public async Task OnGet()
        {
            try
            {
                GitHubBranches = await _gitHubService.GetAspNetCoreDocsBranchesAsync();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
