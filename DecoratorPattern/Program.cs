using System;

namespace DecoratorPattern
{
    /// <summary>
    /// 装饰器模式
    /// 装饰器模式是为已有类在不破坏原来的类的前提下动态的增加更多功能  可以用来实现AOP
    /// 可以将业务代码和系统日志等代码进行分离  这样可以简化原来的类 同样也可以去除相关类中重复的逻辑
    /// 需要注意的是装饰的顺序不同 可能会导致不同的运行结果
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People();

            DecoratorBase decoratorA = new DecoratorA(people);
            DecoratorBase decoratorB = new DecoratorB(decoratorA);
            DecoratorBase decoratorC = new DecoratorC(decoratorB);

            decoratorC.Show();

            Console.WriteLine("Hello World!");
        }
    }
}
