using Consul;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentClassroom_AggregationMicroservice.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentClassroom_AggregationMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStudentClientService _studentClientService = null;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStudentClientService studentClientService)
        {
            _logger = logger;
            _studentClientService = studentClientService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //_studentClientService.GetList();
            //_studentClientService.PollyTimeOut();
            _studentClientService.PollyDown();
            //_studentClientService.PollyDown();


            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
