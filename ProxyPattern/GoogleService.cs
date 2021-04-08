using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPattern
{
    /// <summary>
    /// 需要被代理的资源
    /// </summary>
    public class GoogleService : IService
    {
        public void ReadArticle()
        {
            Console.WriteLine("上谷歌读文章");
        }

        public void WatchTV()
        {
            Console.WriteLine("上谷歌看电视");
        }
    }
}
