using System;
using System.Collections.Generic;
using System.Text;

namespace VistorPattern
{
    /// <summary>
    /// 访问者基类
    /// </summary>
    public abstract class CustomerVistorBase
    {
        public abstract void Visit(Ifood food);
    }

    /// <summary>
    /// 具体的访问者  依赖接口可以通过访问不同的实现 获取到不用的行为
    /// </summary>
    public class CustomerVistor : CustomerVistorBase
    {
        public override void Visit(Ifood food)
        {
            food.Show();
        }
    }
}
