using AutofacIServices;
using AutofacWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestAService _testAService;

        public ITestBService TestBService { set; get; }

        public ITestService TestService { set; get; }

        public HomeController(ILogger<HomeController> logger, ITestAService testAService)
        {
            _logger = logger;
            _testAService = testAService;
        }

        public IActionResult Index()
        {
            _testAService.Show();
            TestBService.Show();
            TestService.Show();
            string result = TestService.TestAop("探清水河", "Asdqwe");

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
