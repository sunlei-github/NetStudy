using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Polly.CircuitBreaker;
using Common_Microservice.Const;
using System.Threading.Tasks;

namespace Common_Microservice.Polly
{
    /// <summary>
    /// Polly的封装
    /// </summary>
    public static class PollyHttpClientServiceCollectionExtensions
    {
        public static IServiceCollection AddPolly(this IServiceCollection services,PollyOption option)
        {
            services.AddHttpClient(ApplicationConst.HTTP_CLINT_POLLY)
                //熔断
                .AddPolicyHandler(Policy<HttpResponseMessage>.Handle<Exception>().CircuitBreakerAsync(option.CircuitBreakerCount, option.CircuitBreakerTime, (ex, ts) =>
            {
                Console.WriteLine($"熔断开启时触发，服务断路器开启，异常消息：{ex.Exception.Message}");
                Console.WriteLine("服务断路器开启时间：100s");
            }, () =>
            {
                Console.WriteLine("熔断恢复时触发");
            }, () =>
            {
                Console.WriteLine($"熔断时间到了之后触发");
            }))
                //降级  返回一个空的HttpResponseMessage信息
                .AddPolicyHandler(Policy<HttpResponseMessage>.HandleInner<Exception>().FallbackAsync(option.FallbackHttpResponseMessage, async b =>
               {
                    // 1、降级打印异常
                    Console.WriteLine($"开始降级,异常消息：{b.Exception.Message}");
                    // 2、降级后的数据
                    Console.WriteLine($"降级内容响应：11111");
                   await Task.CompletedTask;
               }))
                //重试
                .AddPolicyHandler(Policy<HttpResponseMessage>.HandleInner<Exception>().RetryAsync(option.RetryCount))
                //超时
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(option.TimeoutTime));

            return services;
        }
    }

    public class PollyOption
    {
        public int CircuitBreakerCount { set; get; }  //连续请求多少次开启熔断

        public TimeSpan CircuitBreakerTime { set; get; } //开启熔断的时间

        public TimeSpan TimeoutTime { set; get; }  //超时时间

        public int RetryCount { set; get; }  //重试次数

        public HttpResponseMessage FallbackHttpResponseMessage { set; get; }  //降级返回的信息
    }
}
