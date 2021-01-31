using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("启动一个客户端监听!");

            //参考文章：https://www.cnblogs.com/ysyn/p/3399351.html
            //TCP/IP：Transmission Control Protocol/Internet Protocol,传输控制协议/因特网互联协议，又名网络通讯协议。
            //简单来说：TCP控制传输数据，负责发现传输的问题，一旦有问题就发出信号，要求重新传输，直到所有数据安全正确地传输到目的地
            //而IP是负责给因特网中的每一台电脑定义一个地址，以便传输
            //Tcp 协议 通过三次握手 进行连接确认应答
            //Udp 没有连接确认应答 只是单纯的发送信息 速度快 但是可能丢包
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                //创建链接的基础信息
                IPAddress iPAddress = IPAddress.Parse(SocketConst.HOST);
                IPEndPoint endPoint = new IPEndPoint(iPAddress, SocketConst.PORT);
                socket.Connect(endPoint);

                while (true)
                {
                    Console.WriteLine("编辑发送的信息");
                    string sendMsg = Console.ReadLine();

                    if (sendMsg == "exit")
                    {
                        break;
                    }

                    //发送的数据的字节数组
                    byte[] sendMsgBuffer = Encoding.UTF8.GetBytes(sendMsg);
                    socket.Send(sendMsgBuffer);

                    //接收的字节数组
                    byte[] receiveMsgBuffer = new byte[1024 * 5];
                    int bufferLength = socket.Receive(receiveMsgBuffer, SocketFlags.None);

                    string receiveMsg = Encoding.UTF8.GetString(receiveMsgBuffer, 0, bufferLength);
                    Console.WriteLine("收到的信息");
                    Console.WriteLine(receiveMsg);
                }

                //由于socket都是长链接 所以需要手动关闭
                socket.Close();
            }
        }
    }
}
