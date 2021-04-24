using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern
{
    public class CommandMangaer
    {
        private List<CommandBase> commands = new List<CommandBase>();

        /// <summary>
        /// 添加命令
        /// </summary>
        /// <param name="command"></param>
        public void SetCommand(CommandBase command)
        {
            if (!commands.Select(c => c.Name).Contains(command.Name))
            {
                commands.Add(command);
            }
        }

        /// <summary>
        /// 移除命令
        /// </summary>
        /// <param name="command"></param>
        public void RemoveCommand(CommandBase command)
        {
            if (commands.Select(c => c.Name).Contains(command.Name))
            {
                commands.RemoveAll(c => c.Name == command.Name);
            }
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        public void CommandInvoke()
        {
            foreach (var command in commands)
            {
                command.Invoke();
            }
        }
    }
}
