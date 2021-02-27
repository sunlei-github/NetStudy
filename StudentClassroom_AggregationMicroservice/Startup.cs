using Common_Microservice;
using Common_Microservice.Const;
using Common_Microservice.HttpClientConsul;
using Common_Microservice.Polly;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using StudentClassroom_AggregationMicroservice.IServices;
using StudentClassroom_AggregationMicroservice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudentClassroom_AggregationMicroservice
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
            services.AddPolly(new PollyOption {
            CircuitBreakerCount=3,
            CircuitBreakerTime=TimeSpan.FromSeconds(100),
            FallbackHttpResponseMessage=new HttpResponseMessage(),
            RetryCount=5,
            TimeoutTime=TimeSpan.FromSeconds(10)
            }).AddConsulServices();
            services.AddScoped<IStudentClientService, StudentClientService>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
