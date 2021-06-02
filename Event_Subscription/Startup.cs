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


            //����¼�����
            services.AddCap(option =>
            {
                //�־û��յ�����Ϣ  �쳣ʱ���Խ�����������
                option.UseEntityFramework<Sub_DbContext>();
                option.UseSqlServer(conStr);

                // ʹ��RabbitMQ�����¼����Ĵ���
                option.UseRabbitMQ(rb =>
                {
                    rb.HostName = "localhost";
                    rb.UserName = "guest";
                    rb.Password = "guest";
                    rb.Port = 5672;
                    rb.VirtualHost = "/";
                });

                // ���ö�ʱ����������
                option.FailedRetryInterval = 2;
                option.FailedRetryCount = 2; // �������� ��������ʧ�ܺ� ����������ʧ�� ���Խ����˹���Ԥ�����ֶ�����

                // �˹���Ԥ���޸ı��������ҳ��
                option.UseDashboard();  //http://localhost:port/cap  //����ĵ�ַ
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
