using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    public class OperationFactory
    {
        public static OperationBase GetOperation(string operationSymbol)
        {
            return operationSymbol switch
            {
                "-" => new SubOperation(),
                "+" => new SumOperation(),
                "*" => new MulOperation(),
                _ => throw new Exception("符号错误"),
            };
        }
    }
}
