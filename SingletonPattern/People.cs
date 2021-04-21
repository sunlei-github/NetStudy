using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonPattern
{
    public class People
    {
        private static People _people = null;

        private static readonly object locker = new object();

        //静态构造函数可以避免多线程创建多次实例
        //static People()
        //{
        //    _people = new People();
        //}

        /// <summary>
        /// 私有化构造函数 避免外部随便创建实例
        /// </summary>
        private People()
        { }

        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static People GetPeople()
        {
            if (_people == null)
            {
                _people = new People();
                Console.WriteLine("单线程创建实例");
            }

            return _people;
        }

        /// <summary>
        /// 多线程获取单例对象
        /// </summary>
        /// <returns></returns>
        public static People GetTaskPeople()
        {
            //双If加lock 避免多线程创建多个实例
            if (_people == null)
            {
                lock (locker)
                {
                    if (_people == null)
                    {
                        _people = new People();
                        Console.WriteLine("多线程创建实例");
                    }
                }
            }

            return _people;
        }

    }
}
