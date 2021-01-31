using SocketClient;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("启动一个Socket服务器监听!");

            // 根据IP和Port进行实时网络监听
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                IPAddress iPAddress = IPAddress.Parse(SocketConst.HOST);
                IPEndPoint endPoint = new IPEndPoint(iPAddress, SocketConst.PORT);
                socket.Bind(endPoint);
                socket.Listen(0);

                //当服务端监听到客户端的连接请求时  创建一个新的socket链接进行通信 
                using (var socketService = socket.Accept())
                {
                    while (true)
                    {
                        //接收的字节数组
                        byte[] receiveMsgBuffer = new byte[1024 * 5];
                        int bufferLength = socketService.Receive(receiveMsgBuffer, SocketFlags.None);

                        string receiveMsg = Encoding.UTF8.GetString(receiveMsgBuffer, 0, bufferLength);
                        Console.WriteLine("收到的信息");
                        Console.WriteLine(receiveMsg);

                        Console.WriteLine("编辑发送的信息");
                        string sendMsg = Console.ReadLine();

                        if (sendMsg == "exit")
                        {
                            break;
                        }

                        //发送的数据的字节数组
                        byte[] sendMsgBuffer = Encoding.UTF8.GetBytes(sendMsg);
                        socketService.Send(sendMsgBuffer);
                    }

                    socketService.Close();
                }

                socket.Close();
            }
        }
    }
}
