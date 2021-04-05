using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    /// <summary>
    /// 不打折
    /// </summary>
    public class NomalStrategy:IStrategy
    {
        public double GetResult(double pirce)
        {
            return pirce;
        }
    }
}
