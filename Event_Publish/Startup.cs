using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Event_Publish.Context;
using Microsoft.EntityFrameworkCore;

namespace Event_Publish
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
            services.AddControllersWithViews();

            string conStr = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<Pub_DbContext>(option =>
            {
                option.UseSqlServer(conStr);
            });

            services.AddCap(option =>
            {
                // 持久化存储消息(消息发送失败处理)
                option.UseEntityFramework<Pub_DbContext>();
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
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
