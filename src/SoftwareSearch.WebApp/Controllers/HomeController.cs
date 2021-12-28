using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftwareSearch.Domain.Software;
using SoftwareSearch.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SoftwareSearch.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromQuery] SoftwareListRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.SearchText))
                return View(Enumerable.Empty<Software>());

            throw new NotImplementedException("Not implented yet...");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
