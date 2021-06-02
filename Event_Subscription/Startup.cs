using Event_Subscription.Context;
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
using Microsoft.EntityFrameworkCore;

namespace Event_Subscription
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

            string conStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Sub_DbContext>(option =>
            {
                option.UseSqlServer(conStr);
            });


            //添加事件总线
            services.AddCap(option =>
            {
                //持久化收到的信息  异常时可以进行重新消费
                option.UseEntityFramework<Sub_DbContext>();
                option.UseSqlServer(conStr);

                // 使用RabbitMQ进行事件中心处理
                option.UseRabbitMQ(rb =>
                {
                    rb.HostName = "localhost";
                    rb.UserName = "guest";
                    rb.Password = "guest";
                    rb.Port = 5672;
                    rb.VirtualHost = "/";
                });

                // 配置定时器尽早启动
                option.FailedRetryInterval = 2;
                option.FailedRetryCount = 2; // 重试两次 重试两次失败后 该任务将永久失败 可以进行人工干预进行手动消费

                // 人工干预，修改表，后面管理页面
                option.UseDashboard();  //http://localhost:port/cap  //看板的地址
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
