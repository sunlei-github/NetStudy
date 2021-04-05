using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    /// <summary>
    /// 商场促销打折
    /// </summary>
    public class StrategyContext
    {
        /// <summary>
        /// 根据不同的策略获取不同结果
        /// </summary>
        /// <param name="strategyEnum"></param>
        /// <param name="pirce"></param>
        /// <returns></returns>
        public double GetResult(StrategyEnum strategyEnum, double pirce)
        {
            IStrategy strategy = GetStrategy(strategyEnum);
            var result = strategy.GetResult(pirce);
            Console.WriteLine($"现在的价格是{result}");
            return result;
        }

        /// <summary>
        /// 简单工厂 获取策略
        /// </summary>
        /// <param name="strategyEnum"></param>
        /// <returns></returns>
        private IStrategy GetStrategy(StrategyEnum strategyEnum)
        {
            return strategyEnum switch
            {
                StrategyEnum.Normal => new NomalStrategy(),
                StrategyEnum.Discount => new DiscountStrategy(),
                StrategyEnum.Promition => new PromotionStrategy(),
                _ => new NomalStrategy(),
            };
        }

        public enum StrategyEnum
        {
            Normal,
            Discount,
            Promition
        }
    }
}