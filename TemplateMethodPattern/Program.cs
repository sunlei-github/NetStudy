using System;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 模板方法模式
    /// 相对于简单工厂来说 上端变得复杂 但是扩展性强 使用接口 将简单工厂中创建对象的过程进行解耦  
    /// 对于以后对象的创建只需要 增加的对应的工厂即可
    /// 但是上端使用对象时 需要知道的东西太多 对于上端来说反而是变得复杂了
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IFactor englishPeopleFactor = new EnglishPeopleFactor();
            People englishPeople = englishPeopleFactor.CreatePeople();
            englishPeople.Show();

            IFactor chinesePeopleFactor = new ChinesePeopleFactor();
            People chinesePeople = chinesePeopleFactor.CreatePeople();
           chinesePeople.Show();

            Console.WriteLine("Hello World!");
        }
    }
}
