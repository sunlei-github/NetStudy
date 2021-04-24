using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    /// <summary>
    /// 一个贯穿所有命令的类 控制某些命令只能在部分情况下使用
    /// </summary>
    public class CommandContext
    {
        public bool CanInvokeUndoCommand { set; get; }
    }
}
