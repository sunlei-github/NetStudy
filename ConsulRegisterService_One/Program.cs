using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Winton.Extensions.Configuration.Consul;

namespace ConsulRegisterService_One
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((webContext, confBuilder) =>
                    {
                        //webContext.Configuration = confBuilder.Build();

                        string jsonKey = "appsettings.json";
                        string filoderKey = webContext.HostingEnvironment.ApplicationName + "/" + jsonKey;
                        Console.WriteLine(filoderKey);

                        //���ع̶�key�������ļ�  key="appsettings.json"
                        confBuilder.AddConsul(jsonKey, op =>
                         {
                             op.ConsulConfigurationOptions = cco => { cco.Address = new Uri("http://127.0.0.1:8500"); };

                             op.Optional = true;  //���������ļ�
                             op.ReloadOnChange = true;  //�����ļ��޸ĺ� ���¼���

                             op.OnLoadException = op => { op.Ignore = true; }; //���Լ����ļ�ʱ���쳣
                         })
                        .AddConsul(filoderKey, op =>
                        {
                            op.ConsulConfigurationOptions = cco => { cco.Address = new Uri("http://127.0.0.1:8500"); };

                            op.Optional = true;  //���������ļ�
                            op.ReloadOnChange = true;  //�����ļ��޸ĺ� ���¼���

                            op.OnLoadException = op => { op.Ignore = true; }; //���Լ����ļ�ʱ���쳣
                        });

                        //���¹������ó���������ļ�
                        webContext.Configuration = confBuilder.Build();
                    });




                    webBuilder.UseStartup<Startup>();
                });
    }
}
