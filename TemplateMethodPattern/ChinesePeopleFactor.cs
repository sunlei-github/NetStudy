using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethodPattern
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
