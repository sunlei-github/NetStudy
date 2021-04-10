using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern
{
    /// <summary>
    /// 中国人工厂
    /// </summary>
    public class ChinesePeopleFactor : IFactor
    {
        public People CreatePeople()
        {
            return new ChinesePeople();
        }
    }
}
