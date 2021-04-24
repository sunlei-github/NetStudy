using System;

namespace ChainOfResponsibilityPattern
{
    /// <summary>
    /// 责任链模式
    /// 使得多个对象都有机会去处理请求，从而避免请求的发送者和接收者之间的耦合，将这些对象连城一条链，并沿着
    /// 这条链传递该请求，直到有一个对象处理它对象。
    /// 接收者和发送者都没有对方的明确信息，且链中的对象自己也并不知道链的结构，结果是职责链可简化对象的相互连接
    /// 他们仅需要保持一个指向其后继者的引用，而不需要保存它所有的候选者的引用。
    /// 
    /// 由于每一部分的链都是相互独立的 所以之后可以更方便的扩展链
    /// 但是对于客户端来说需要合适的去配置链 否则一个请求可能就到达了链的末端也得不到处理
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ManagerBase ceo = new CEO("ceo", null);
            ManagerBase projectMajor = new ProjectMajor("主管", ceo);
            ManagerBase projectManager = new ProjectManager("项目经理", projectMajor);

            SickNoteContext sickNoteContext = new SickNoteContext
            {
                Hour = 26,
                Message = "有事"
            };

            projectManager.Handle(sickNoteContext);
            Console.WriteLine("Hello World!");
        }
    }
}
