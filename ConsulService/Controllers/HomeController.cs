using Consul;
using ConsulService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsulService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            #region 从Consul中去获取已经注册的服务
            ConsulClient consulClient = new ConsulClient(op =>
            {
                op.Address = new Uri("http://127.0.0.1:8500");
            });

            var serviceDic = (await consulClient.Agent.Services()).Response;
            string requestUri = "/weatherforecast/get";
            const string groupName = "One_Name";   //请求的服务组名称

            var agentServices = serviceDic.Where(c => c.Value.Service == groupName).ToList();
            var agentService = agentServices.First();
            string requestUrl = $"http://{agentService.Value.Address}:{agentService.Value.Port}{requestUri}";

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUrl));
            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                string result = await httpResponseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
            #endregion




            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {




            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
