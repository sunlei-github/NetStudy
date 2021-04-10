using System;

namespace PrototypePattern
{
    /// <summary>
    /// 原型模式主要是使用了 MemberwiseClone()方法 进行浅克隆  
    /// 浅克隆： 被复制的对象的所有变量都含有与原来的对象相同的值，而所有的队其他对象的引用仍然都指向原来的对象
    /// （如果字段是值类型，则对该字段进行逐位复制，如果字段是引用类型，则复制引用不复制引用的对象，也就是如果被复制的对象
    /// 中含有引用类型的字段，则被复制的对象和赋值后的对象 引用类型的字段都是指向同一个实例的）
    /// 深克隆：则正好与浅克隆相反，不论被克隆的对象的字段是值类型还是引用类型都会进行复制
    /// 
    /// 原型模式的好处是 构建对象时可以保留上了对象的基本信息 并且原型模式构建对象是不需要走构造函数的 如果构造函数中
    /// 有许多需要初始化的信息 那么原型模式则可以减少创建对象的时间 并且原型模式对上端也隐藏了创建对象的细节
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IdentityCard identityCard = new IdentityCard("地球");
            People people = new People("小明", 18);
            people.IdentityCard = identityCard;

            People people1 =people.Clone() as People;
            people1.Name = "小王";
            people1.Old = 20;
            people1.IdentityCard.Adress = "火星";

            people.Show();
            people1.Show();
            people.Show();

            Console.WriteLine("Hello World!");
        }
    }
}
