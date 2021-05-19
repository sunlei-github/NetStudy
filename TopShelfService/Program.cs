using System;
using Topshelf;

namespace TopShelfService
{
    /// <summary>
    /// 使用Topshelf开发Windows服务，比起直接写Windows服务的优势在于，可以直接运行调试。开发完成后，直接使用install命令注册为服务即可，简单高效。
    /// 官方文档  http://docs.topshelf-project.com/en/latest/configuration/config_api.html 
    /// 
    /// 服务安装卸载
    /// 安装：TopShelfService.exe install
    ///启动：TopShelfService.exe start
    ///卸载：TopShelfService.exe uninstall
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(conf =>
            {
                conf.SetDisplayName("test_displayname");
                conf.SetServiceName("test_servicename");
                conf.SetInstanceName("test_instancename");
                conf.SetDescription("服务描述");

                conf.SetStartTimeout(TimeSpan.FromSeconds(10));  //设置服务启动超时的时间
                conf.SetStopTimeout(TimeSpan.FromSeconds(10));  //设置服务停止超时的时间

                conf.Service<TestService>(op =>
                {
                    //自定义服务的配置  使用有参数的构造函数
                    op.ConstructUsing(() => new TestService("服务名称"));
                    op.WhenStarted((service, host) => service.Start(host));
                    op.WhenStopped((service, host) => service.Stop(host));

                });  //注册服务   对服务进行自定义配置

                //服务安装 卸载 前后的事件
                conf.BeforeInstall(c => Console.WriteLine("服务开始安装之前"));
                conf.AfterInstall(c => Console.WriteLine("服务安装之后"));
                conf.BeforeUninstall(() => Console.WriteLine("服务卸载之前"));
                conf.AfterUninstall(() => Console.WriteLine("服务卸载之后"));

                conf.UseLog4Net("log4Net.config");  //使用log4net 
            });

            Console.WriteLine("Hello World!");
        }
    }
}
