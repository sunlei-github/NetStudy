using System;

namespace BuilderPattern
{
    /// <summary>
    /// 建造者模式
    /// 将一个复杂对象的构建与他的表示分离，使得同样的构建过程可以实现不同的结果
    /// 建造者对象中可以指定 需要构建的对象的所有的基本数据 以及指定所建造对象的基本数据的顺序（也会标准建造者的指挥者对象） 从而达到不同的效果
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            HamburgerBuilderBase hamburgerBuilder = new HamburgerBuilder();
            HamburgerBase hamburger = hamburgerBuilder.GetHamburger();
            hamburger.Show();
 
            Console.WriteLine("Hello World!");
        }
    }
}
