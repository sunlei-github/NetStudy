using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    /// <summary>
    /// 减法
    /// </summary>
    public class SubOperation : OperationBase
    {
        public override double GetResult(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
