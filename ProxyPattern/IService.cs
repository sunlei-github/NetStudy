using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPattern
{
    /// <summary>
    /// 网站的一些基本服务
    /// </summary>
    public interface IService
    {

        void ReadArticle();

        void WatchTV();

    }
}
