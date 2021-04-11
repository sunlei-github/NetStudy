using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 学生B答题
    /// </summary>
    public class StudentB : ExaminationQuestionBase
    {
        public StudentB(string name) : base(name)
        { }

        public override void AnswerA(string answer)
        {
            Console.WriteLine($"{Name}的A选择题没做");
        }

        public override void AnswerB(string answer)
        {
            Console.WriteLine($"{Name}的B选择题没做");
        }
    }
}
