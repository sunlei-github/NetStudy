using System;
using System.Collections.Generic;
using System.Threading;

namespace FlyweightPattern
{
    /// <summary>
    /// 享元模式
    /// 使用共享技术，有效的支持大量细粒度的对象 提高性能 降低内存消耗
    /// 享元模式可以避免大量非常相似类的开销
    /// 如果几个类的内部状态相似（构造函数）并且他们都有相同的功能
    /// 那么就可以  单独抽取一个类出来 使用享元模式让那几个类共享这一个抽离出来的实例
    /// 如果这几个类的外部状态不同 那么可以将他们的外部状态整合到享元模式的内部 也就是整合成方法 
    /// 但是强行将几个类整合成一个享元则会降低类的扩展性 不利于维护 而且会使得享元变得很臃肿 使得享元也变得很复杂
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<string> colors = new List<string>()
            {
                "红色","绿色","蓝色","绿色","红色","绿色","蓝色","红色","红色","蓝色"
            };

            FlyweightCircleFactory flyweightCircleFactory = new FlyweightCircleFactory();

            foreach (var color in colors)
            {
                int x = new Random(DateTime.Now.Millisecond).Next(0, 1000);
                int y = new Random(DateTime.Now.Millisecond + 10).Next(0, 1000);
                Circle circle = flyweightCircleFactory.GetCircle(color);
                circle.Draw(x, y);
                Thread.Sleep(200);
            }

            flyweightCircleFactory.ShowCircleCount();

            //字符串使用的就是享元模式
            //string a = "A";
            //string b = "A";
            //Console.WriteLine(object.ReferenceEquals(a, b));

            Console.WriteLine("Hello World!");
        }
    }
}
