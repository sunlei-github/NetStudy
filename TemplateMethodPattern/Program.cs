using System;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 模板方法模式
    /// 将不变的行为搬移超父类中去（或者是将一部分业务重复的代码逻辑上移到父类中去，或者是在父类中定义好算法的骨架）
    /// 将一些步骤延迟到子类中去
    /// 这样既可以去除重复的代码 使程序变得更好维护 又可以在一定程度上减少编码的错误
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ExaminationQuestionBase sA = new StudentA("小明");
            sA.QuestionA();
            sA.AnswerA("A");
            sA.QuestionB();
            sA.AnswerB("D");

            ExaminationQuestionBase sB = new StudentB("小王");
            sB.QuestionA();
            sB.AnswerA(string.Empty);
            sB.QuestionB();
            sB.AnswerB(string.Empty);

            Console.WriteLine("Hello World!");
        }
    }
}
