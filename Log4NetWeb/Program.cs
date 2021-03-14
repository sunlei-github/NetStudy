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
                // 因为系统日志会很多
                loggingBuilder.AddFilter("System", LogLevel.Information);
                loggingBuilder.AddFilter("Microsoft", LogLevel.Warning);//过滤掉系统默认的一些日志  警告级别一下的日志被过滤掉
                loggingBuilder.AddLog4Net();
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
