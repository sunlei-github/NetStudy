using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 单例模式 
    /// 应用全局只能使用一个该对象的实例 所以首先需要私有化构造函数 避免外部随便创建实例
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //People p1 = People.GetPeople();
            //People p2 = People.GetPeople();
            //Console.WriteLine(object.ReferenceEquals(p1, p2));

            List<Task> tasks = new List<Task>();

            //for (int i = 0; i < 10; i++)
            //{
            //    tasks.Add(Task.Run(() =>
            //    {
            //        People p = People.GetPeople();
            //    }));
            //}

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    People p = People.GetTaskPeople();
                }));
            }
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Hello World!");
        }
    }
}
