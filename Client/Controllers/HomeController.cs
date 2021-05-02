using Client.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("ClientLogin");
        }

        [HttpGet]
        public async  Task<IActionResult> ClientLogin()
        {
            HttpClient httpClient = new HttpClient();
            //链接鉴权中心 获取token
            DiscoveryDocumentResponse disco = await httpClient.GetDiscoveryDocumentAsync("http://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine($"[DiscoveryDocumentResponse Error]: {disco.Error}");
            }

            TokenResponse tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
            {
                ClientId = "client",  //客户端地址
                ClientSecret = "secret",  //客户端密码
                Address = disco.TokenEndpoint,  //获取token的地址
                Scope = "bookScope" //要访问的资源
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine("Token获取失败");
                Console.WriteLine(tokenResponse.Error);

                return new JsonResult("Token获取失败");
            }

            Console.WriteLine("Token获取成功");
            Console.WriteLine(tokenResponse.AccessToken);
            Console.WriteLine(tokenResponse.RefreshToken);
            Console.WriteLine(tokenResponse.ExpiresIn);

            //使用token调用保护的资源
            HttpClient sourceHttpClient = new HttpClient();
            sourceHttpClient.SetBearerToken(tokenResponse.AccessToken);
            HttpResponseMessage responce = await sourceHttpClient.GetAsync("http://localhost:5005/api/source/getbooks");
            if (!responce.IsSuccessStatusCode)
            {
                Console.WriteLine("保护资源调用失败");
                return new JsonResult("保护资源调用失败");
            }

            string result = await responce.Content.ReadAsStringAsync();
            Console.WriteLine("资源获取成功");
            return new JsonResult(result);
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
