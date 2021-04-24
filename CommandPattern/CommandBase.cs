using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    /// <summary>
    /// 命令模式
    /// </summary>
    public abstract class CommandBase
    {
        private readonly string _name;
        private readonly CommandContext _commandContext;

        public string Name
        {
            private set { value = _name; }

            get { return _name; }

        }

        public CommandContext CommandContext { set { value = _commandContext; } get { return _commandContext; } }

        public CommandBase(string name,CommandContext commandContext)
        {
            _name = name;
            _commandContext = commandContext;
        }

        /// <summary>
        /// 命令执行
        /// </summary>
        public abstract void Invoke();
    }
}
