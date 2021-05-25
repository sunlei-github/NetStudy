using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsulRegisterService_One
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            ConsulClient consulClient = new ConsulClient(op =>
            {
                op.Address = new Uri("http://127.0.0.1:8500");
            });

            #region 向Consul注册服务
            // dotnet ConsulRegisterService_One.dll --urls http://*:5007 --port 5007  --ip 127.0.0.1
            string serviceAdress = Configuration["ip"];  //从命令行读取Ip
            int port = int.Parse(Configuration["port"]);  //从命令行读取端口

            string healthUri = $"http://{serviceAdress}:{port}/weatherforecast/Health";
            Console.WriteLine(healthUri);

            consulClient.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = Guid.NewGuid().ToString(), //服务唯一编号
                Address = serviceAdress,  //注册的服务的ip
                Name = "One_Name", // 服务组名称
                Port = port,  // 注册的服务的端口 
                Tags = new string[] { "tag" },
                Check = new AgentServiceCheck
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(10),  //10秒后移除无超时的服务
                    HTTP = healthUri, // 心跳检查的地址
                    Interval = TimeSpan.FromSeconds(5),  //五秒进行一次心跳检查
                    Timeout = TimeSpan.FromSeconds(5)  //如果五秒后无反应 则认为是超时
                }
            }).Wait(); 
            #endregion


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
