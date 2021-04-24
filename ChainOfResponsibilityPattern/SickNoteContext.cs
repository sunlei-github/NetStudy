using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityPattern
{
    /// <summary>
    /// 请假条上下文
    /// </summary>
    public class SickNoteContext
    {
        /// <summary>
        /// 请假信息
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// 请假时间
        /// </summary>
        public int Hour { set; get; }
    }
}
