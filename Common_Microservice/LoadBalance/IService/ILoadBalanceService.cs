using Consul;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Microservice.LoadBalance.IService
{
    /// <summary>
    /// 负载均衡策略
    /// </summary>
    public interface ILoadBalanceService
    {
        /// <summary>
        /// 随机策略
        /// </summary>
        /// <param name="catalogServices"></param>
        /// <returns></returns>
        CatalogService RandomBalance(IList<CatalogService> catalogServices);

        /// <summary>
        /// 权重策略
        /// </summary>
        /// <param name="catalogServices"></param>
        /// <returns></returns>
        CatalogService WeightBalance(IList<CatalogService> catalogServices);

        /// <summary>
        /// 轮询策略
        /// </summary>
        /// <param name="catalogServices"></param>
        /// <returns></returns>
        CatalogService PollBalance(IList<CatalogService> catalogServices);

        /// <summary>
        /// Ip_Hash
        /// </summary>
        /// <param name="catalogServices"></param>
        /// <returns></returns>
        CatalogService IpHashBalance(IList<CatalogService> catalogServices);
    }
}
