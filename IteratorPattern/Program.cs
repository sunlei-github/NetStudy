using System;
using System.Collections.Generic;

namespace IteratorPattern
{
    /// <summary>
    /// 迭代器模式是最常用的设计模式
    /// 通常使用的 for  foreach 等都是迭代器模式的使用
    /// net中的迭代器接口是 IEnumerator
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<object> arrary = new List<object>
            {
                "小明","小红","小刚","小菊"
            };

            CustomerIterator iterator = new CustomerIterator(arrary);
            Console.WriteLine($"第一个元素是{iterator.First().ToString()}");
            Console.WriteLine($"最后一个元素是{iterator.Last().ToString()}");

            while (iterator.MoveNext())
            {
                Console.WriteLine($"元素值是{iterator.Next().ToString()}");
            }

            iterator[2] = "AAA";
            Console.WriteLine($"修改的元素是{iterator[2]}");

            Console.WriteLine("Hello World!");
        }
    }
}
