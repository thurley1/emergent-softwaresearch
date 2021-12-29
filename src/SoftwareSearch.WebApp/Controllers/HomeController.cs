using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftwareSearch.Domain.Software.Models;
using SoftwareSearch.Domain.Software.Services;
using SoftwareSearch.WebApp.Models;
using System.Diagnostics;
using System.Linq;

namespace SoftwareSearch.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISoftwareSearch _softwareManager;

        public HomeController(ILogger<HomeController> logger, ISoftwareSearch softwareManager)
        {
            _logger = logger;
            _softwareManager = softwareManager;
        }

        public IActionResult Index([FromQuery] SoftwareListRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.SearchText))
                return View(Enumerable.Empty<SoftwareInfo>());

            var results = _softwareManager.SearchVersions(request.SearchText);
            return View(results.OrderBy(v => v.Name).ThenBy(v => v.Version));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
