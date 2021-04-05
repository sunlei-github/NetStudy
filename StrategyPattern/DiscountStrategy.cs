using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    /// <summary>
    /// 打九折
    /// </summary>
    public class DiscountStrategy : IStrategy
    {
        public double GetResult(double pirce)
        {
            return pirce * 0.9;
        }
    }
}
