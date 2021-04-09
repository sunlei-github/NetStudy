using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethodPattern
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
