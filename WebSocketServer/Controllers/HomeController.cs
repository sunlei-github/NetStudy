using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Web.WebSockets;
using System.Net.WebSockets;

namespace WebSocketServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //初始化群聊信息
            if (HomeController.webSocketMsg.Count == 0)
            {
                string[] users = new string[3] { "Mike", "John", "Jim" };
                for (int i = 0; i < users.Length; i++)
                {
                    HomeController.webSocketMsg.Add(users[i],
                    new WebScoketUserModel
                    {
                        IsLogin = false,
                        OfficeMessage = new List<string>(),
                        UserName = users[i],
                        WebSocket = null
                    });
                }
            }

            return View();
        }

        public string loginUser = string.Empty;
        /// <summary>
        /// 登陆一个用户
        /// </summary>
        /// <param name="name"></param>
        public void WebSocket(string name)
        {
            if (HttpContext.IsWebSocketRequest)
            {
                loginUser = name;
                //HttpContext.AcceptWebSocketRequest(HandleWebSocket);
                HttpContext.AcceptWebSocketRequest(ChatWebSocket);
            }
            else
            {
                HttpContext.Response.Write("只能处理WebSocket请求");
            }
        }

        /// <summary>
        /// 网页聊天室
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task ChatWebSocket(AspNetWebSocketContext context)
        {
            var webSocket = context.WebSocket;
            WebScoketUserModel userModel = HomeController.webSocketMsg.Values.FirstOrDefault(c => c.UserName == loginUser);
            if (userModel == null)
            {
                byte[] byteArr = Encoding.UTF8.GetBytes("您未加入该群聊");
                ArraySegment<byte> responceSegment = new ArraySegment<byte>(byteArr, 0, byteArr.Length);

                await webSocket.SendAsync(responceSegment, System.Net.WebSockets.WebSocketMessageType.Text, true, new System.Threading.CancellationToken());
            }
            else
            {
                userModel.IsLogin = true;
                userModel.WebSocket = webSocket;

                while (true)
                {
                    if (webSocket.State == WebSocketState.Open)
                    {
                        //如果有离线信息 先发送离线信息
                        if (userModel.OfficeMessage.Count > 0)
                        {
                            foreach (var item in userModel.OfficeMessage)
                            {
                                byte[] byteArr = Encoding.UTF8.GetBytes($"离线信息+{item}");
                                ArraySegment<byte> responceSegment = new ArraySegment<byte>(byteArr, 0, byteArr.Length);

                                await webSocket.SendAsync(responceSegment, System.Net.WebSockets.WebSocketMessageType.Text, true, new System.Threading.CancellationToken());
                            }

                            //清除所有的离线信息
                            userModel.OfficeMessage = new List<string>();
                        }

                        byte[] receiveBytes = new byte[2048];
                        var receiveSegment = await webSocket.ReceiveAsync(new ArraySegment<byte>(receiveBytes), new System.Threading.CancellationToken());

                        //用户退出时  向聊天室所有在线的用户发出信息
                        if (receiveSegment.MessageType == WebSocketMessageType.Close)
                        {
                            byte[] byteArr = Encoding.UTF8.GetBytes($"{userModel.UserName}退出聊天室");
                            ArraySegment<byte> responceSegment = new ArraySegment<byte>(byteArr, 0, byteArr.Length);
                            foreach (var item in HomeController.webSocketMsg.Values.Where(c => c.IsLogin && c.UserName != userModel.UserName))
                            {
                                await item.WebSocket.SendAsync(responceSegment, System.Net.WebSockets.WebSocketMessageType.Text, true, new System.Threading.CancellationToken());
                            }

                            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, $"{userModel.UserName}退出聊天室", new System.Threading.CancellationToken());
                            userModel.IsLogin = false;
                        }

                        if (webSocket.State == WebSocketState.Closed)
                        {
                            return;
                        }

                        string receiveMsg = Encoding.UTF8.GetString(receiveBytes, 0, receiveBytes.Count());
                        string msg = $"{loginUser}：{receiveMsg}";

                        //查找未登录的用户  添加离线信息
                        foreach (var item in HomeController.webSocketMsg.Values.Where(c => !c.IsLogin))
                        {
                            item.OfficeMessage.Add(msg);
                        }

                        foreach (var item in HomeController.webSocketMsg.Values)
                        {
                            if (item.IsLogin && item.WebSocket != null)
                            {
                                byte[] byteArr = Encoding.UTF8.GetBytes(msg);
                                ArraySegment<byte> responceSegment = new ArraySegment<byte>(byteArr, 0, byteArr.Length);

                                await item.WebSocket.SendAsync(responceSegment, System.Net.WebSockets.WebSocketMessageType.Text, true, new System.Threading.CancellationToken());
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 服务器返回的消息  服务端再返回一次信息后 会自动关闭socket连接
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task HandleWebSocket(AspNetWebSocketContext context)
        {
            var webSocket = context.WebSocket;
            string msg = "服务器返回的信息";
            byte[] byteArr = Encoding.UTF8.GetBytes(msg);
            ArraySegment<byte> responceSegment = new ArraySegment<byte>(byteArr, 0, byteArr.Length);

            if (webSocket.State == System.Net.WebSockets.WebSocketState.Open)
            {
                await webSocket.SendAsync(responceSegment, System.Net.WebSockets.WebSocketMessageType.Text, true, new System.Threading.CancellationToken());
            }
        }


        /// <summary>
        /// 群聊的人员及信息
        /// </summary>
        public static Dictionary<string, WebScoketUserModel> webSocketMsg = new Dictionary<string, WebScoketUserModel>();

        public class WebScoketUserModel
        {
            /// <summary>
            /// 连接的用户
            /// </summary>
            public string UserName { set; get; }

            /// <summary>
            /// 是否登陆
            /// </summary>
            public bool IsLogin { set; get; }

            /// <summary>
            /// 用户的WebSocket 连接通道
            /// </summary>
            public WebSocket WebSocket { set; get; }

            /// <summary>
            /// 离线消息
            /// </summary>
            public List<string> OfficeMessage { set; get; }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}