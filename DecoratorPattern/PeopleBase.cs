using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    /// <summary>
    /// 要装饰的物体的基类 也是装饰器的基类
    /// </summary>
    public abstract class PeopleBase
    {
        public abstract void Show();
    }

    public class People : PeopleBase
    {
        public override void Show()
        {
            Console.WriteLine("这是一个人");
        }
    }
}
