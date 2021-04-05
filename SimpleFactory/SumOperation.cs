using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    /// <summary>
    /// 加法
    /// </summary>
    public class SumOperation : OperationBase
    {
        public override double GetResult(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}
