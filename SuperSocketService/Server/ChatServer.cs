using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocketService.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketService.Server
{
    /// <summary>
    /// 一个对话服务
    /// </summary>
    [AuthorisizeFilter]
    public class ChatServer : AppServer<ChatSession>
    {
        /// <summary>
        /// 服务开始
        /// </summary>
        protected override void OnStarted()
        {
            Console.WriteLine("Session 服务开始");
            base.OnStarted();
        }

        /// <summary>
        /// 服务停止
        /// </summary>
        protected override void OnStopped()
        {
            Console.WriteLine("Session 服务停止");
            base.OnStopped();
        }

    }
}
