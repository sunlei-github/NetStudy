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
            //������Ҫ����.AddControllers() �ÿ�����������Ӧ��ʵ����������������������ע���Ϊ�գ�
            //services.AddControllers().AddControllersAsServices();
            services.AddControllers().AddControllersAsServices();
            services.AddControllersWithViews();  //��䲻��ȥ�� �����ע����ͼ����
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            //����������еĿ����� Ȼ��ͳһע��
            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
                .Where(type => typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(type)).ToArray();
            containerBuilder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();

            #region һ��ĵ��÷�ʽ
            //containerBuilder.RegisterType<TestAService>().As<ITestAService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<TestBService>().As<ITestBService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<TestCService>().As<ITestCService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<TestDService>().As<ITestDService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<TestService>().As<ITestService>().InstancePerLifetimeScope().PropertiesAutowired();  // PropertiesAutowired() ֧������ע��
            //var container = containerBuilder.Build();
            //var aService = container.Resolve<ITestAService>();
            //aService.Show(); 
            #endregion

            #region actofac����������
            //containerBuilder.RegisterType<TestAService>().As<ITestAService>().InstancePerDependency();   //˲ʱ��������
            //containerBuilder.RegisterType<TestBService>().As<ITestBService>().InstancePerLifetimeScope();   //��������������
            //containerBuilder.RegisterType<TestCService>().As<ITestCService>().SingleInstance(); //������������ 
            #endregion

            containerBuilder.RegisterType<CutomAutofacAop>(); //ע��Aop
            var iAssemably = Assembly.Load("AutofacIServices");
            var cAssemably = Assembly.Load("AutofacServices");
            containerBuilder.RegisterAssemblyTypes(iAssemably, cAssemably).AsImplementedInterfaces().PropertiesAutowired()
                .EnableInterfaceInterceptors();  //.EnableInterfaceInterceptors();   ����aop

            //ʹ�ó���ע��
            //var iAssemably = Assembly.Load("AutofacIServices");
            //var cAssemably = Assembly.Load("AutofacServices");
            //containerBuilder.RegisterAssemblyTypes(iAssemably, cAssemably).AsImplementedInterfaces().PropertiesAutowired();

            //����ģ�黯ע�� ��Ҫ�̳�Autofac.Module  
            //֧�ֵ��ӿ� ��ʵ�ֵ�ע��
            //֧�������ļ�ע�� ��Ҫ����ʵ����ͽӿ�ֱ�ӵĹ�ϵ  �Ƚϸ���
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
