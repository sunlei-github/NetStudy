using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketService
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                IBootstrap bootstrap = BootstrapFactory.CreateBootstrap();
                if (!bootstrap.Initialize())
                {
                    Console.WriteLine("Socket初始化失败");
                    Console.ReadLine();
                }

                var startResult = bootstrap.Start();

                if (startResult != StartResult.Success)
                {
                    Console.WriteLine("Socket启动失败");
                    Console.ReadLine();
                }

                foreach (var server in bootstrap.AppServers)
                {
                    if (server.State == ServerState.Running)
                    {
                        Console.WriteLine($"{server.Name} 服务正在运行中");
                    }
                    else
                    {
                        Console.WriteLine($"{server.Name} 服务的状态是{server.State.ToString()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("程序异常");
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
