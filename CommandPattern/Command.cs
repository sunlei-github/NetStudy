using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class UndoCommand : CommandBase
    {
        public UndoCommand(string name, CommandContext commandContext) : base(name, commandContext)
        {
        }

        public override void Invoke()
        {
            if (CommandContext.CanInvokeUndoCommand)
            {
                Console.WriteLine("执行撤销操作");
            }
            else
            {
                Console.WriteLine("不能执行该操作");
            }
        }
    }

    public class CopyCommand : CommandBase
    {
        public CopyCommand(string name, CommandContext commandContext) : base(name, commandContext)
        {
        }

        public override void Invoke()
        {
            Console.WriteLine("执行复制操作");
        }
    }

    public class CutCommand : CommandBase
    {
        public CutCommand(string name, CommandContext commandContext) : base(name, commandContext)
        {
        }

        public override void Invoke()
        {
            Console.WriteLine("执行剪切操作");
        }
    }
}
