using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace AbstractFactorPattern
{
    public abstract class AbstractFactorBase
    {
        public abstract FactorType CreateFactor<FactorType>()
            where FactorType : IFactor, new();
    }

    /// <summary>
    /// 抽象工厂 只负责创建工厂
    /// </summary>
    /// <typeparam name="FactorType"></typeparam>
    public class AbstractFactor : AbstractFactorBase
    {
        public override FactorType CreateFactor<FactorType>()
        {
            return Activator.CreateInstance<FactorType>();
        }
    }
}
