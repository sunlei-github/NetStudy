using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactorPattern
{
    /// <summary>
    /// 中国人
    /// </summary>
    public class ChinesePeople : People
    {
        public override void Show()
        {
            Console.WriteLine("我是中国人");
        }
    }
}
