using Common_Microservice.LoadBalance.IService;
using Consul;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Microservice.LoadBalance.Service
{
    public class LoadBalanceService : ILoadBalanceService
    {

        public CatalogService IpHashBalance(IList<CatalogService> catalogServices)
        {
            throw new NotImplementedException();
        }

        public CatalogService PollBalance(IList<CatalogService> catalogServices)
        {
            throw new NotImplementedException();
        }

        public CatalogService RandomBalance(IList<CatalogService> catalogServices)
        {
            Random random = new Random(DateTime.UtcNow.Millisecond);
            int randomIndex = random.Next(0, catalogServices.Count);

            return catalogServices[randomIndex];
        }

        public CatalogService WeightBalance(IList<CatalogService> catalogServices)
        {
            throw new NotImplementedException();
        }
    }
}
