using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log4NetWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging(loggingBuilder => 
            {
                // ��Ϊϵͳ��־��ܶ�
                loggingBuilder.AddFilter("System", LogLevel.Information);
                loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);//���˵�ϵͳĬ�ϵ�һЩ��־  ���漶��һ�µ���־�����˵�
                loggingBuilder.AddLog4Net();
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
