using Autofac.Extras.DynamicProxy;
using AutofacIServices.Aop;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacIServices
{
    [Intercept(typeof(CutomAutofacAop))]  //只能标注在接口或者实现类上
    public interface ITestService
    {
        void Show();

        string TestAop(string name, string pwd);
    }
}
