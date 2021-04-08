using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPattern
{
    /// <summary>
    /// 代理服务器
    /// </summary>
    public class ProxyService : IService
    {
        /// <summary>
        /// 代理的服务
        /// </summary>
        private IService _service = null;

        /// <summary>
        /// 注册代理的服务
        /// </summary>
        /// <param name="service"></param>
        public ProxyService(IService service)
        {
            _service = service;
        }

        public void ReadArticle()
        {
            _service.ReadArticle();
        }

        public void WatchTV()
        {
            _service.WatchTV();
        }
    }
}
