using System;

namespace StrategyPattern
{
    /// <summary>
    /// 策略模式
    /// 策略模式旨在将一个功能块不同的变化封装起来 然后通过策略中心去在不同的场景下调用不同的策略实现不同的功能
    /// 虽然 看起来工厂类似  但是工厂的重点都是在创建对象的工程 而策略模式是跟倾向于业务
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            StrategyContext context = new StrategyContext();
            var result1 = context.GetResult(StrategyContext.StrategyEnum.Normal, 1100);
            var result2 = context.GetResult(StrategyContext.StrategyEnum.Discount, result1);
            context.GetResult(StrategyContext.StrategyEnum.Promition, result2);

            Console.WriteLine("Hello World!");
        }
    }
}
