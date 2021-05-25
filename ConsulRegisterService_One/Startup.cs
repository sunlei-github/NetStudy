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

            #region ��Consulע�����
            // dotnet ConsulRegisterService_One.dll --urls http://*:5007 --port 5007  --ip 127.0.0.1
            string serviceAdress = Configuration["ip"];  //�������ж�ȡIp
            int port = int.Parse(Configuration["port"]);  //�������ж�ȡ�˿�

            string healthUri = $"http://{serviceAdress}:{port}/weatherforecast/Health";
            Console.WriteLine(healthUri);

            consulClient.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = Guid.NewGuid().ToString(), //����Ψһ���
                Address = serviceAdress,  //ע��ķ����ip
                Name = "One_Name", // ����������
                Port = port,  // ע��ķ���Ķ˿� 
                Tags = new string[] { "tag" },
                Check = new AgentServiceCheck
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(10),  //10����Ƴ��޳�ʱ�ķ���
                    HTTP = healthUri, // �������ĵ�ַ
                    Interval = TimeSpan.FromSeconds(5),  //�������һ���������
                    Timeout = TimeSpan.FromSeconds(5)  //���������޷�Ӧ ����Ϊ�ǳ�ʱ
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
