using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    public abstract class OperationBase
    {
        public abstract double GetResult(double num1, double num2);
    }
}
