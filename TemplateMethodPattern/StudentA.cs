using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 学生A答题
    /// </summary>
    public class StudentA : ExaminationQuestionBase
    {
        public StudentA(string name) : base(name)
        { }

        public override void AnswerA(string answer)
        {
            base.AnswerA(answer);
        }

        public override void AnswerB(string answer)
        {
            base.AnswerB(answer);
        }
    }
}
