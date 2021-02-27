using Common_Microservice.HttpClientConsul.IService;
using Common_Microservice.HttpClientConsul.Service;
using Common_Microservice.LoadBalance.IService;
using Common_Microservice.LoadBalance.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Microservice.HttpClientConsul
{
    /// <summary>
    /// Consul服务Api和负载均衡策略的封装
    /// </summary>
    public static class ConsulHttpClientServiceCollectionExtensions
    {
        public static IServiceCollection AddConsulServices(this IServiceCollection services)
        {
            services.AddScoped<IConsulClientService, ConsulClientService>();
            services.AddScoped<ILoadBalanceService, LoadBalanceService>();

            return services;
        }
    }
}
