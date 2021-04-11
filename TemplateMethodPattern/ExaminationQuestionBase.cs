using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethodPattern
{
    /// <summary>
    /// 试卷的基本信息
    /// </summary>
    public abstract class ExaminationQuestionBase
    {
        public string Name { set; get; }

        public ExaminationQuestionBase(string name)
        {
            Name = name;
        }

        public void QuestionA()
        {
            Console.WriteLine("这是一道选择题A一共有4个选项（ABCD），请选择");
        }

        public void QuestionB()
        {
            Console.WriteLine("这是选择题B一共有4个选项（ABCD），请选择");
        }

        public virtual void AnswerA(string answer)
        {
            Console.WriteLine($"选择题A{Name}选择了{answer}");
        }

        public virtual void AnswerB(string answer)
        {
            Console.WriteLine($"选择题B{Name}选择了{answer}");
        }
    }
}
