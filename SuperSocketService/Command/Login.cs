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
    public class Login : CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters.Length == 2)
            {
                string userName = requestInfo.Parameters[0];
                string userPwd = requestInfo.Parameters[1];

                //查询账号 是否已经登陆
                ChatSession hasChatSession = session.AppServer.GetAllSessions().Where(c => c.UserName == userName).FirstOrDefault();
                if (hasChatSession != null)
                {
                    hasChatSession.Send("您的账号在其他地方登陆");
                    hasChatSession.Close();
                }

                //账号登陆
                if (userPwd == "123")
                {
                    session.Send($"登陆的用户名是{userName}---{session.SessionID}");
                    session.UserName = userName;
                    session.IsLogin = true;

                    //检查离线状态  是否有其他用户给发送信息
                    var hasOfficeMsg = OfficeMessageCache.MsgDictionary.Keys.FirstOrDefault(c => c == userName);
                    if (hasOfficeMsg != null)
                    {
                        var officeMsgs = OfficeMessageCache.MsgDictionary[userName];
                        if (officeMsgs.Count > 0)
                        {
                            //逐条发送离线 信息
                            foreach (var msg in officeMsgs)
                            {
                                session.Send($"离线信息---{msg}");
                            }
                        }
                    }
                }
            }
        }
    }
}
