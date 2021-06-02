using DotNetCore.CAP;
using Event_Subscription.Context;
using Event_Subscription.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Event_Subscription.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Sub_DbContext _sub_DbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Sub_DbContext sub_DbContext)
        {
            _logger = logger;
            _sub_DbContext = sub_DbContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [NonAction]  // 不允许使用请求动词访问
        [CapSubscribe("Subscribe_Name_Test")]   //指明监听者的名称(或者说是路径)  支持通配符 *监听多个  #监听第一个 
        public async Task<IActionResult> SubscribeEvent(Event subEvent)
        {
            await _sub_DbContext.Events.AddAsync(subEvent);
            Thread.Sleep(10000000);
            await _sub_DbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
