using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePattern
{
    /// <summary>
    /// 桥接类
    /// </summary>
    public class ServerBridge
    {
        private readonly IServer server;

        public ServerBridge(IServer server)
        {
            this.server = server;
        }

        public void LinkServer()
        {
            server.Link();
        }
    }
}
