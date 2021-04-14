using System;

namespace ObserverPattern
{
    /// <summary>
    /// 观察者模式
    /// 
    /// 观察者 可以注册到对应的通知者上 观察者和通知者都有自己的状态 但是当通知者的状态改变时会影响到所有的观察者 并向他们发出信息
    /// 定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个对象主题，当这个主题对应的状态发生变化时，会通知所有观察者对象，使他们能够自己更新自己。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            SubjectBase subject = new Subject();
            ObserverBase observerA = new ObserverA("士兵1", subject);
            ObserverBase observerB = new ObserverB("士兵2", subject);
            ObserverBase observerC = new ObserverC("士兵3", subject);
            subject.RegisterObserver(observerA);
            subject.RegisterObserver(observerB);
            subject.RegisterObserver(observerC);

            Console.WriteLine("早上巡逻");
            subject.State = "B";
            subject.Notify();

            Console.WriteLine("晚上巡逻");
            subject.State = "A";
            subject.Notify();

            Console.WriteLine("Hello World!");
        }
    }
}
