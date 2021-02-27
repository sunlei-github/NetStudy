using Common_Microservice.Const;
using Common_Microservice.HttpClientConsul.Dto;
using Common_Microservice.HttpClientConsul.IService;
using Common_Microservice.HttpClientConsul.Service;
using Consul;
using StudentClassroom_AggregationMicroservice.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudentClassroom_AggregationMicroservice.Services
{
    public class StudentClientService : IStudentClientService
    {
        private readonly IConsulClientService _consulClientService = null;
        private readonly IHttpClientFactory _httpClientFactory = null;
        public StudentClientService(IConsulClientService consulClientService, IHttpClientFactory httpClientFactory)
        {
            _consulClientService = consulClientService;
            _httpClientFactory = httpClientFactory;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public string GetList()
        {
            GetConsulClientOption option = new GetConsulClientOption
            {
                ServiceGroupName = "StudentGroup",
                UriAdress = "/api/student/getlist"
            };
            HttpResponseMessage response = _consulClientService.GetAsync(option).Result;

            return string.Empty;
        }

        /// <summary>
        /// 测试Pooly超时
        /// </summary>
        public  void PollyTimeOut()
        {
            GetConsulClientOption option = new GetConsulClientOption
            {
                ServiceGroupName = "StudentGroup",
                UriAdress = "/api/student/pollytimeout"
            };

            for (int i = 0; i < 100; i++)
            {
                try
                {
                    HttpResponseMessage response = _consulClientService.GetAsync(option).Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"捕获的异常{ex.Message}");
                }
            }
        }

        public void PollyDown()
        {
          
                HttpClient httpClient = _httpClientFactory.CreateClient(ApplicationConst.HTTP_CLINT_POLLY);
                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        HttpResponseMessage response = httpClient.GetAsync("https://localhost:5001").Result;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("捕获的异常" + ex.Message);
                    }
                }
        }
    }
}
