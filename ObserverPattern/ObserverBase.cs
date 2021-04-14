using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public abstract class ObserverBase
    {
        protected string name;

        private string observerState;

        protected SubjectBase subject;

        public ObserverBase(string name, SubjectBase subject)
        {
            this.name = name;
            this.subject = subject;
        }

        public virtual void UpdateState()
        {
            this.observerState = subject.State;
            if (this.observerState == "A")
            {
                Console.WriteLine($"士兵{name}开始防御");
            }
            else
            {
                Console.WriteLine($"士兵{name}无事发生");
            }
        }

    }

    public class ObserverA : ObserverBase
    {
        public ObserverA(string name, SubjectBase subject) : base(name, subject)
        {
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }
    }

    public class ObserverB : ObserverBase
    {
        public ObserverB(string name, SubjectBase subject) : base(name, subject)
        {
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }
    }

    public class ObserverC : ObserverBase
    {
        public ObserverC(string name, SubjectBase subject) : base(name, subject)
        {
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }
    }
}
