using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    /// <summary>
    /// 装饰器需要去指定需要装饰的对象 通过方法 或者构造函数去指定装饰的对象
    /// </summary>
    public abstract class DecoratorBase : PeopleBase
    {
        protected PeopleBase _people = null;

        public DecoratorBase(PeopleBase people)
        {
            _people = people;
        }

        //protected abstract void ResterPeople(PeopleBase people));
    }

    public class DecoratorA : DecoratorBase
    {
        public DecoratorA(PeopleBase people) : base(people)
        { }

        public override void Show()
        {
            if (_people != null)
            {
                Console.WriteLine($"{nameof(DecoratorA)}装饰前");
                _people.Show();
                Console.WriteLine($"{nameof(DecoratorA)}装饰后");
            }
        }
    }

    public class DecoratorB : DecoratorBase
    {
        public DecoratorB(PeopleBase people) : base(people)
        { }

        public override void Show()
        {
            if (_people != null)
            {
                Console.WriteLine($"{nameof(DecoratorB)}装饰前");
                _people.Show();
                Console.WriteLine($"{nameof(DecoratorB)}装饰后");
            }
        }
    }

    public class DecoratorC : DecoratorBase
    {
        public DecoratorC(PeopleBase people) : base(people)
        { }

        public override void Show()
        {
            if (_people != null)
            {
                Console.WriteLine($"{nameof(DecoratorC)}装饰前");
                _people.Show();
                Console.WriteLine($"{nameof(DecoratorC)}装饰后");
            }
        }
    }
}
