using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using AutofacIServices;
using AutofacIServices.Aop;
using AutofacServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AutofacWeb
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
            //这里需要加上.AddControllers() 让控制器创建对应的实例（否则控制器里面的属性注入会为空）
            //services.AddControllers().AddControllersAsServices();
            services.AddControllers().AddControllersAsServices();
            services.AddControllersWithViews();  //这句不能去掉 这里会注入视图服务
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            //反射加载所有的控制器 然后统一注入
            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
                .Where(type => typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(type)).ToArray();
            containerBuilder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();

            #region 一般的调用方式
            //containerBuilder.RegisterType<TestAService>().As<ITestAService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<TestBService>().As<ITestBService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<TestCService>().As<ITestCService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<TestDService>().As<ITestDService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<TestService>().As<ITestService>().InstancePerLifetimeScope().PropertiesAutowired();  // PropertiesAutowired() 支持属性注入
            //var container = containerBuilder.Build();
            //var aService = container.Resolve<ITestAService>();
            //aService.Show(); 
            #endregion

            #region actofac的生命周期
            //containerBuilder.RegisterType<TestAService>().As<ITestAService>().InstancePerDependency();   //瞬时生命周期
            //containerBuilder.RegisterType<TestBService>().As<ITestBService>().InstancePerLifetimeScope();   //作用域生命周期
            //containerBuilder.RegisterType<TestCService>().As<ITestCService>().SingleInstance(); //单例生命周期 
            #endregion

            containerBuilder.RegisterType<CutomAutofacAop>(); //注册Aop
            var iAssemably = Assembly.Load("AutofacIServices");
            var cAssemably = Assembly.Load("AutofacServices");
            containerBuilder.RegisterAssemblyTypes(iAssemably, cAssemably).AsImplementedInterfaces().PropertiesAutowired()
                .EnableInterfaceInterceptors();  //.EnableInterfaceInterceptors();   启用aop

            //使用程序集注入
            //var iAssemably = Assembly.Load("AutofacIServices");
            //var cAssemably = Assembly.Load("AutofacServices");
            //containerBuilder.RegisterAssemblyTypes(iAssemably, cAssemably).AsImplementedInterfaces().PropertiesAutowired();

            //主持模块化注入 需要继承Autofac.Module  
            //支持单接口 多实现的注入
            //支持配置文件注入 需要配置实现类和接口直接的关系  比较复杂
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
