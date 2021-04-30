using System;

namespace VistorPattern
{
    /// <summary>
    /// 访问者模式
    /// 设计模式的作者是这么评价访问者模式的：大多情况下，你并不需要使用访问者模式，但是一旦需要使用它时，那就真的需要使用了。
    /// 解耦了数据结构和数据操作使得数据结构可以独立变化 被访问者职责单一（如果较多则难以维护） 但是可以被访问很方便的可以进行扩展
    /// 如果被访问者是经常变化的  那么就必须修改被访问的代码 未被开闭原则
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CustomerVistorBase customerVistor = new CustomerVistor();
            FoodMenu foodMenu = new FoodMenu();
            foodMenu.AddFood(new ChickenFood());
            foodMenu.AddFood(new RiceFood());

            foodMenu.Show(customerVistor);

            Console.WriteLine("Hello World!");
        }
    }
}
