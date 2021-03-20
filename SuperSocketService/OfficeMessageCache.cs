using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketService
{
    /// <summary>
    /// 离线信息的缓存
    /// </summary>
    public class OfficeMessageCache
    {
        /// <summary>
        /// 缓存的信息
        /// </summary>
        public static Dictionary<string, List<string>> MsgDictionary = new Dictionary<string, List<string>>();
    }
}
