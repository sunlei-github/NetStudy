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
    /// 和其他客户交流
    /// </summary>
    public class Chatc : CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters.Length == 2)
            {
                //要沟通的用户
                string talkUser = requestInfo.Parameters[0];
                //交流的信息
                string talkMsg = requestInfo.Parameters[1];

                var talkSession = session.AppServer.GetAllSessions().FirstOrDefault(c => c.UserName == talkUser);
                //如果用户登陆了
                if (talkSession != null)
                {
                    talkSession.Send(talkMsg);
                }
                //用户离线 则将其他用户发送的信息放到缓存中
                else
                {
                    var hasTalkUser = OfficeMessageCache.MsgDictionary.Keys.FirstOrDefault(c => c == talkUser);
                    //如果缓存的信息中没有该用户
                    if (string.IsNullOrEmpty(hasTalkUser))
                    {
                        OfficeMessageCache.MsgDictionary.Add(talkUser, new List<string>() { talkMsg });
                    }
                    else
                    {
                        OfficeMessageCache.MsgDictionary.First(c => c.Key == talkUser).Value.Add(talkMsg);
                    }
                }
            }
        }
    }
}
