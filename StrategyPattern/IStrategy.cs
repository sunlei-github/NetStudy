using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    /// <summary>
    /// 销售策略
    /// </summary>
    public interface IStrategy
    {
        double GetResult(double pirce);
    }
}
