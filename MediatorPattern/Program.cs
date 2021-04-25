using System;

namespace MediatorPattern
{
    /// <summary>
    /// 中介者模式
    /// 中介者模式遵循着迪米特法则（最少知识原则）
    ///尽管讲一个类分割成许多对象通常可以增加其可复用性，但是对象直接项目连接的激增又会降低其可复用性
    ///所以 当类与类需要通信时我们可以考虑使用中介者模式 来降低类与类之间的耦合 也可以将一些复杂的逻辑转移到对应的中介者中
    ///使的每个类的职责单一 
    ///但是频繁的使用中介者模式会使得程序变得很臃肿 更加复杂 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MediatorBase mediator = new ZiRu();
            mediator.Name = "自如";

            landlordBase landlord = new landlord(mediator);
            landlord.Name = "小东房东";
            TenantBase tenant = new Tenant(mediator);
            tenant.Name = "小明租客";
            mediator.landlord = landlord;
            mediator.Tenant = tenant;

            mediator.IandlorDregisterHouse(1200);
            mediator.TenantRentHouse(1200);
            mediator.CoordinateHousePirce(1200);

            Console.WriteLine("Hello World!");
        }
    }
}
