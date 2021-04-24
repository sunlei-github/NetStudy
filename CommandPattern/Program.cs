using System;

namespace CommandPattern
{
    /// <summary>
    /// 命令模式
    /// 对请求就行排队 允许请求方决定是是否撤销之前的请求 各个命令相互独立互不影响 方便扩展新的命令
    /// 使的一些具体的请求对客户端来说变成参数化的操作
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CommandContext commandContext = new CommandContext();
            CommandBase undo = new UndoCommand("撤销", commandContext);
            CommandBase copy = new CopyCommand("复制", commandContext);
            CommandBase cut = new CutCommand("剪切", commandContext);

            CommandMangaer commandMangaer = new CommandMangaer();
            commandMangaer.SetCommand(undo);
            commandMangaer.SetCommand(copy);
            commandMangaer.SetCommand(cut);

            commandMangaer.CommandInvoke();

            commandContext.CanInvokeUndoCommand = true;
            commandMangaer.CommandInvoke();

            Console.WriteLine("Hello World!");
        }
    }
}
