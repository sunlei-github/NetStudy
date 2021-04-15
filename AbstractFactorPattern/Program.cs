using System;

namespace AbstractFactorPattern
{
    /// <summary>
    /// 抽象工厂
    /// 便于交换产品系列 只需要修改对应的工厂类型便会 产生不同的实例
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactorBase abstractFactor = new AbstractFactor();
            ChinesePeopleFactor chinesePeopleFactor = abstractFactor.CreateFactor<ChinesePeopleFactor>();
            EnglishPeopleFactor englishPeopleFactor = abstractFactor.CreateFactor<EnglishPeopleFactor>();
            chinesePeopleFactor.CreatePeople().Show();
            englishPeopleFactor.CreatePeople().Show();

            Console.WriteLine("Hello World!");
        }
    }
}
