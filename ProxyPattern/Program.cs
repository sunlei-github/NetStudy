using System;

namespace ProxyPattern
{
    class Program
    {
        /// <summary>
        /// 代理模式一般不会添加太多除提供服务之外的逻辑
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            GoogleService googleService = new GoogleService();
            ProxyService proxyService = new ProxyService(googleService);

            People people = new People();
            people.VisitServeice(proxyService);


            Console.WriteLine("Hello World!");
        }
    }
}
