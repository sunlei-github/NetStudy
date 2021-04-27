using System;

namespace InterpreterPattern
{
    /// <summary>
    /// 解释器模式 
    /// 如果一种特定类型的问题发生的频率够高并且复杂，那么可能就值得将该问题的各个实例表述为一个简单语言中的句子。这样就
    /// 可以构建一个解释器，该解释器通过解释这些句子来解决该问题。
    /// 为文法中的每一条规则至少定义一个类 因此包含许多规则的文法可能难以管理和维护
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            InterpreterContext context = new InterpreterContext();
            context.EnglishWord = "hello";
            context.ConcatWord = "world";

            InterpreterBase concatInterpreter = new ConcatInterpreter();
            concatInterpreter.Interpreter(context);
            InterpreterBase toUpperInterpreter = new ToUpperInterpreter();
            toUpperInterpreter.Interpreter(context);

            Console.WriteLine(context.EnglishWord);
        }
    }
}
