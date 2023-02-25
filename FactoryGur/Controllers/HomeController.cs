using FactoryGur.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FactoryGur.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly GitHubService _gitHubService;
        private readonly IGitHubClient _gitHubClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, GitHubService gitHubService, IGitHubClient gitHubClient)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _gitHubService = gitHubService;
            _gitHubClient = gitHubClient;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public async Task<IActionResult> BasicUsage()
        {
            var model1 = new BasicModel(_httpClientFactory);
            await model1.OnGet();
            return View(model1.GitHubBranches);
        }

        public async Task<IActionResult> NamedClients()
        {
            var model1 = new NamedClientModel(_httpClientFactory);
            await model1.OnGet();
            return View(model1.GitHubBranches);
        }

        public async Task<IActionResult> TypedClients()
        {
            var typedClient = new TypedClientModel(_gitHubService);
            await typedClient.OnGet();
            return View(typedClient.GitHubBranches);
        }

        public async Task<IActionResult> GeneratedClients()
        {
            var model1 = new RefitModel(_gitHubClient);
            await model1.OnGet();
            return View(model1.GitHubBranches);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}