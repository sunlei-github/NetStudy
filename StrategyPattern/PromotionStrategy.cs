using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    /// <summary>
    /// 满300减100
    /// </summary>
    public class PromotionStrategy : IStrategy
    {
        public double GetResult(double pirce)
        {
            return pirce > 300 ? pirce - (Math.Floor(pirce / 300) * 100) : pirce;
        }
    }
}
