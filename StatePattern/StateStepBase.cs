using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    /// <summary>
    /// 状态类的父类
    /// </summary>
    public abstract class StateStepBase
    {
        public abstract void Invoke(StateContext context);
    }

    /// <summary>
    /// 状态类具体的实现
    /// </summary>
    public class StateStepA : StateStepBase
    {
        public override void Invoke(StateContext context)
        {
            if (context.State == "A")
            {
                Console.WriteLine("这里是状态步骤A，执行结束");
            }
            else
            {
                StateStepBase stateStep = new StateStepB();
                stateStep.Invoke(context);
            }
        }
    }
    public class StateStepB : StateStepBase
    {
        public override void Invoke(StateContext context)
        {
            if (context.State == "B")
            {
                Console.WriteLine("这里是状态步骤B，执行结束");
            }
            else 
            {
                StateStepBase stateStep = new StateStepC();
                stateStep.Invoke(context);
            }
        }
    }
    public class StateStepC : StateStepBase
    {
        public override void Invoke(StateContext context)
        {
            if (context.State == "C")
            {
                Console.WriteLine("这里是状态步骤C，执行结束");
            }
            else
            {
                Console.WriteLine("没有合适的步骤去执行");
            }
        }
    }
}
