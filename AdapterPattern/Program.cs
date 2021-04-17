using System;

namespace AdapterPattern
{
    class Program
    {
        /// <summary>
        /// 适配器模式
        /// 将一个类的接口转换成客户所需要的另一个接口。适配器模式使得原本由于接口不兼容而不能在一起工作的那些类可以一起工作了
        /// 主要用于希望一些现存的类，但是又与复用环境要求不一致的情况 
        /// 也或者是对接第三方时，三方的一些接口不能合适的在现有的系统中去使用时 
        /// 有点 使得客户端可以统一调用同一个接口 是系统更简单，更直接，更紧凑
        /// 适配器模式更适合补锅 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ThridPartyCalculate thridPartyCalculate = new ThridPartyCalculate();
            CalculateAdapter calculateAdapter = new CalculateAdapter(thridPartyCalculate);

            IOurSyetemOperation ourSyetemOperation = new OurSyetemOperation(calculateAdapter);
            double result1 = ourSyetemOperation.Add(1, 2);
            double result2 = ourSyetemOperation.Sub(11, 2);
            double result3 = ourSyetemOperation.Mul(12, 2);
            double result4 = ourSyetemOperation.Div(13, 2);

            Console.WriteLine("Hello World!");
        }
    }
}
