using System;
using System.Collections.Generic;
using System.Text;
using Topshelf;

namespace TopShelfService
{
    public class TestService : ServiceControl
    {

        public TestService() { }

        public TestService(string name)
        {
            Console.WriteLine("使用有参数的构造函数");
        }

        public bool Start(HostControl hostControl)
        {
            Console.WriteLine("TestService服务已经开始执行");

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Console.WriteLine("TestService服务已经已经停止");

            return true;
        }
    }
}
