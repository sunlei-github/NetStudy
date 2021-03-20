using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperSocketService.Session
{
    public class ChatSession : AppSession<ChatSession>
    {
        /// <summary>
        /// 登陆的用户
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 是否存活
        /// </summary>
        public bool IsAlive { set; get; }

        public bool IsLogin { set; get; }

        /// <summary>
        /// 初始化一个对话Session
        /// </summary>
        protected override void OnInit()
        {
            //启动一个线程 进行心跳检测
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        Send("OK");
                    }
                    catch (Exception ex)
                    {
                        IsAlive = false;
                        Console.WriteLine("系统异常");
                        Console.WriteLine(ex.Message);
                        Close();
                    }

                    Thread.Sleep(1000);
                }
            });

            Console.WriteLine("初始化一个Session");
            base.OnInit();
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="message"></param>
        public override void Send(string message)
        {
            Console.WriteLine($"发送一个信息--{message}");
            //为发送的信息添加 换行符
            base.Send(message + "\r\n");
        }

        /// <summary>
        /// 不能识别的一个命令
        /// </summary>
        /// <param name="requestInfo"></param>
        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            Console.WriteLine("不能识别的命令");
            base.HandleUnknownRequest(requestInfo);
        }

        /// <summary>
        /// 链接异常
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            Console.WriteLine("链接中异常");
            base.HandleException(e);
        }

        /// <summary>
        /// 连接开始
        /// </summary>
        protected override void OnSessionStarted()
        {
            Console.WriteLine("连接已经开始");
            base.OnSessionStarted();
        }

        /// <summary>
        /// 连接关闭
        /// </summary>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            Console.WriteLine("连接失败");
            base.OnSessionClosed(reason);
        }
    }
}
