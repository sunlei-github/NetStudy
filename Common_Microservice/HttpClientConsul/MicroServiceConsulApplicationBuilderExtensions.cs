using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Microservice.HttpClientConsul
{
    /// <summary>
    /// Consul的服务注册扩展
    /// </summary>
    public static class MicroServiceConsulApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseConsul(this IApplicationBuilder builder, IConfiguration configuration)
        {
            ConsulRegiterOption option = configuration.GetSection("Consul").Get<ConsulRegiterOption>();
            option.ServicePort = Convert.ToInt32(configuration["port"]);
            Console.WriteLine($"端口是{option.ServicePort}");

            ConsulClient consulClient = new ConsulClient(c =>
            {
                c.Address = new Uri(option.ConsulAdress);
            });

            string healthCheckUri = $"{option.ServiceBaseAdress}:{option.ServicePort}{option.HeathOption.HttpUri}";
            Console.WriteLine(healthCheckUri);

            AgentServiceRegistration agentServiceRegistration = new AgentServiceRegistration
            {
                ID = Guid.NewGuid().ToString(),  // 服务Id
                Address = option.ServiceBaseAdress,    //服务地址
                Port = option.ServicePort,   //服务端口
                Name = option.ServiceGroupName,  //服务组名称
                Tags = option.ServiceTags,  //服务标签
                Check = new AgentServiceCheck   //服务健康检查
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(option.HeathOption.DeregisterCriticalServiceAfter),  //服务5秒无响应则移除服务
                    HTTP = healthCheckUri, //健康检查地址
                    Timeout = TimeSpan.FromMilliseconds(option.HeathOption.Timeout), //服务10秒无响应则认为服务已经过期了
                    Interval = TimeSpan.FromMilliseconds(option.HeathOption.Interval)  //3秒进行一次心跳检查
                }
            };

            consulClient.Agent.ServiceRegister(agentServiceRegistration).Wait();

            return builder;
        }
    }

    public class ConsulRegiterOption
    {
        public string ConsulAdress { set; get; }

        public string ServiceBaseAdress { set; get; }

        public int ServicePort { set; get; }

        public string ServiceGroupName { set; get; }

        public string[] ServiceTags { set; get; }

        public ConsulHeathOption HeathOption { set; get; }
    }

    public class ConsulHeathOption
    {
        public double DeregisterCriticalServiceAfter { set; get; }

        public string HttpUri { set; get; }

        public double Timeout { set; get; }

        public double Interval { set; get; }
    }
}
