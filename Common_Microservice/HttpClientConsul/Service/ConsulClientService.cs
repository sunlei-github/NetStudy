using Common_Microservice.Const;
using Common_Microservice.HttpClientConsul.Dto;
using Common_Microservice.HttpClientConsul.IService;
using Common_Microservice.LoadBalance.IService;
using Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Common_Microservice.HttpClientConsul.Service
{
    public class ConsulClientService : IConsulClientService
    {
        private readonly IHttpClientFactory _httpClientFactory = null;
        private readonly ILoadBalanceService _loadBalanceService = null;

        public ConsulClientService(IHttpClientFactory httpClientFactory, ILoadBalanceService loadBalanceService)
        {
            _httpClientFactory = httpClientFactory;
            _loadBalanceService = loadBalanceService;
        }

        public Task<HttpResponseMessage> DeleteAsync(DeleteConsulClientOption option)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> GetAsync(GetConsulClientOption option)
        {
            var services = await Discovery(option.ServiceGroupName);
            var service = _loadBalanceService.RandomBalance(services);
            string requestUrl = $"{service.ServiceAddress}:{service.ServicePort}{option.UriAdress}";


            var client = _httpClientFactory.CreateClient(ApplicationConst.HTTP_CLINT_POLLY);
            var resopnce = await client.GetAsync(requestUrl);
            var result = await resopnce.Content.ReadAsStringAsync();

            return resopnce;
        }

        public Task<HttpResponseMessage> PostAsync(PostConsulClientOption option)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PutAsync(PutConsulClientOption option)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 服务的发现
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        private async Task<IList<CatalogService>> Discovery(string serviceName)
        {
            ConsulClient consulClient = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500");
            });

            return (await consulClient.Catalog.Service(serviceName)).Response.ToList();
        }
    }
}
