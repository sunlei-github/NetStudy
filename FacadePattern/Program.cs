using System;

namespace FacadePattern
{
    /// <summary>
    /// 外观模式 （门面模式）
    /// 为子系统中的一组接口提供一个一致的界面，此模式定义了一个高层的接口，这个接口使得子系统更加的容易使用
    /// 比如业务逻辑层和表示层之间监理外观，为复杂的子系统提供一个简单的接口，使得耦合降低
    /// 在维护比较古老的一个项目的时候可以建立一个外观模式 让新系统与外观对象交互  外观则与遗留的复杂代码就行交互 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IOldServiceA oldServiceA = new OldServiceA();
            IOldServiceB oldServiceB = new OldServiceB();
            Facade facade = new Facade(oldServiceA, oldServiceB);
            INewService service = new NewService(facade);
            service.ShowA();
            service.ShowB();

            Console.WriteLine("Hello World!");
        }
    }
}
