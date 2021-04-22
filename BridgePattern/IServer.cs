using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePattern
{
    /// <summary>
    /// 服务器
    /// </summary>
    public interface IServer
    {
        void Link();
    }

    public class ServerA : IServer
    {
        public void Link()
        {
            Console.WriteLine("链接A服务器");
        }
    }

    public class ServerB : IServer
    {
        public void Link()
        {
            Console.WriteLine("链接B服务器");
        }
    }
}
