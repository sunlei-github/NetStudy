using DotNetCore.CAP;
using Event_Publish.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Event_Publish.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //引入事件发布者
        private readonly ICapPublisher _capPublisher;

        public HomeController(ILogger<HomeController> logger, ICapPublisher capPublisher)
        {
            _logger = logger;
            _capPublisher = capPublisher;
        }

        public async Task<IActionResult> Index()
        {
            Event model = new Event()
            {
                EventContent = "AAA" + DateTime.Now.ToString(),
                EventName = "一个事件"
            };

            //发布事件 该事件将有 名称（路径是）Subscribe_Name_Test的消费者监听
            await _capPublisher.PublishAsync<Event>("Subscribe_Name_Test", model);

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
