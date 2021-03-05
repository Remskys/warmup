using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dummy_app.Models;
using Microsoft.Extensions.Configuration;
using dummy_app.Helpers;
using System.Threading;

namespace dummy_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        
        private readonly int? _fakeLoadMultiplier = null;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            if (int.TryParse(_configuration["FakeLoadMultiplier"], out int value) && value > 0)
            {
                _fakeLoadMultiplier = value;
            }
        }

        public IActionResult Index()
        {
            if (_fakeLoadMultiplier.HasValue)
            {
                FakeLoadHelper.EmulateCpuLoad(_fakeLoadMultiplier.Value);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            if (_fakeLoadMultiplier.HasValue)
            {
                FakeLoadHelper.EmulateCpuLoad(_fakeLoadMultiplier.Value);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
