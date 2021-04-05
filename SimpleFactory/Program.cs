using System;

namespace SimpleFactory
{
    class Program
    {
        /// <summary>
        /// 简单工厂
        /// 可以选择性的根据不同的情景获取不同的实例 
        /// 对上端屏蔽了获取对象的细节 所有对象的细节都集中封装到简单工厂中  上端变得稳定 修改都集中到工厂中去
        /// 扩展性强 如果之后想添加其他运算 只需要继续增加对应的实现类（要遵循单一职责原则）即可 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            OperationBase operation = OperationFactory.GetOperation("+");
            double result = operation.GetResult(10, 100);
            Console.WriteLine($"结果是{result}");

            Console.WriteLine("Hello World!");
        }
    }
}
