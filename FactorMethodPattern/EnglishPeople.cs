using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern
{
    /// <summary>
    /// 美国人
    /// </summary>
    public class EnglishPeople : People
    {
        public override void Show()
        {
            Console.WriteLine("我是一个美国人");
        }
    }
}
