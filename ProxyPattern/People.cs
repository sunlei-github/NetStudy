using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPattern
{
    /// <summary>
    /// 客户端使用代理访问谷歌服务器
    /// </summary>
    public class People
    {

        public void VisitServeice(IService service)
        {
            Console.WriteLine("小明浏览网站中");
            service.ReadArticle();
            service.WatchTV();
        }
    }
}
