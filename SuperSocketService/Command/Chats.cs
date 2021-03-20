using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocketService.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketService.Command
{

    /// <summary>
    /// 和服务器交流
    /// </summary>
    public class Chats : CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine("开始处理命令");
            Console.WriteLine(requestInfo.Body);
            Console.WriteLine(requestInfo.Key);

            //发送信息
            if (requestInfo.Parameters.Length > 0)
            {
                session.Send(string.Join(",", requestInfo.Parameters));
            }
        }
    }
}
