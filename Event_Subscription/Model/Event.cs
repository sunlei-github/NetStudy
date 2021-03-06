﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_Subscription.Model
{
    /// <summary>
    /// 监听的事件模型
    /// </summary>
    public class Event
    {

        public string Id { set; get; } = Guid.NewGuid().ToString();

        public string EventName { set; get; }

        public string EventContent { set; get; }

        public DateTime CreateTime { set; get; } = DateTime.Now;
    }
}
