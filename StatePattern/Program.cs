using System;

namespace StatePattern
{
    class Program
    {
        /// <summary>
        /// 状态模式
        /// 当一个对象的内在状态变化时 允许改变其行为这个对象想是改变了类 
        /// 一般的实现思路  if  else switch 分支判断  但是当对象的状态很多时  会导致方法体很长很臃肿  耦合严重 
        /// 状态模式会将不同的状态 创建一个对应的状态类 每个状态类只维护一种状态 这些状态类 共享一个需要改变状态的对象
        /// 而且每个状态类 都需要显示指定他们下一步的状态类 也是执行步骤
        /// 状态模式是将对应的对象的状态 从对应的方法上转移到了们状态的子类上
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            StateStepBase stateStepA = new StateStepA();
            StateContext context = new StateContext(stateStepA)
            {
                State = "C"
            };

            context.Handler();
        }
    }
}
