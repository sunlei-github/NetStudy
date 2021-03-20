using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Metadata;
using SuperSocketService.Command;
using SuperSocketService.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketService
{
    public class AuthorisizeFilterAttribute : CommandFilterAttribute
    {
        /// <summary>
        /// 命令执行前的执行
        /// </summary>
        /// <param name="commandContext"></param>
        public override void OnCommandExecuted(CommandExecutingContext commandContext)
        {
            if (commandContext.Session is ChatSession chatSession)
            {
                if (!chatSession.IsLogin&&chatSession.IsAlive)
                {
                    if (chatSession.CurrentCommand.Equals(nameof(Login)))
                    {
                        return;
                    }
                    else
                    {
                        //取消当前命令
                        chatSession.Send("请先登陆");
                        commandContext.Cancel = true;
                    }
                }
            }
        }

        /// <summary>
        /// 命令执行后的操作
        /// </summary>
        /// <param name="commandContext"></param>
        public override void OnCommandExecuting(CommandExecutingContext commandContext)
        {
        }
    }
}
