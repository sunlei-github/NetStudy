using System;

namespace BridgePattern
{
    /// <summary>
    /// 桥接模式
    /// 将抽象部分与实现部分进行分离  实现部分有多角度的演化时 如果客户端直接调用实现则客户端与实现类偶尔严重
    /// 客户端通过调用桥接类 将客户端与实现类的耦合转移到了桥接类与实现类上 使客户端相对趋于稳定
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ServerBridge serverBridgeA = new ServerBridge(new ServerA());
            serverBridgeA.LinkServer();

            ServerBridge serverBridgeB = new ServerBridge(new ServerB());
            serverBridgeB.LinkServer();

            Console.WriteLine("Hello World!");
        }
    }
}
