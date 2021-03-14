using Log4NetWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Log4NetWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ILoggerFactory _loggerFactory;

        public HomeController(ILogger<HomeController> logger, ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _logger = logger;

            _logger.LogWarning("ILogger记录日志");
            var log = _loggerFactory.CreateLogger<HomeController>();
            log.LogInformation("ILoggerFactory记录日志");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
