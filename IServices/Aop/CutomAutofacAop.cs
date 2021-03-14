using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacIServices.Aop
{
    public class CutomAutofacAop : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //获取参数
            foreach (var item in invocation.Arguments)
            {
                Console.WriteLine(item.ToString());
            }

            invocation.Proceed();  //调用目标方法

            invocation.ReturnValue = "aaaa";  //设置返回值

            //Console.WriteLine("方法调用完了");
        }
    }
}
