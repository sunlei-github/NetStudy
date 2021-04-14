using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    /// <summary>
    /// 通知者  ==  订阅者
    /// </summary>
    public abstract class SubjectBase
    {
        protected List<ObserverBase> observers = new List<ObserverBase>();

        public string State { set; get; }

        /// <summary>
        /// 注册观察者  == 事件订阅
        /// </summary>
        /// <param name="observer"></param>
        public virtual void RegisterObserver(ObserverBase observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// 移除观察者 == 事件取消订阅
        /// </summary>
        /// <param name="observer"></param>
        public virtual void RemoveObserver(ObserverBase observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        /// <summary>
        /// 通知所有的观察者 === 事件发布
        /// </summary>
        public abstract void Notify();
    }

    public class Subject : SubjectBase
    {
        public override void Notify()
        {
            foreach (var observer in observers)
            {
                //通知所有订阅的人
                observer.UpdateState();
            }
        }
    }
}
