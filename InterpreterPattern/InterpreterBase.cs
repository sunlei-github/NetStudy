using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterPattern
{
    /// <summary>
    /// 解释器基类
    /// </summary>
    public abstract class InterpreterBase
    {

        public abstract void Interpreter(InterpreterContext context);
    }

    /// <summary>
    /// 转换成大写的解释器
    /// </summary>
    public class ToUpperInterpreter : InterpreterBase
    {
        public override void Interpreter(InterpreterContext context)
        {
            context.EnglishWord = context.EnglishWord.ToUpper();
        }
    }

    /// <summary>
    /// 连接字符串的解释器
    /// </summary>
    public class ConcatInterpreter : InterpreterBase
    {
        public override void Interpreter(InterpreterContext context)
        {
            context.EnglishWord = context.EnglishWord + " " + context.ConcatWord;
        }
    }
}
