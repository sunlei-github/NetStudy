using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityPattern
{
    public class ProjectManager : ManagerBase
    {
        public ProjectManager(string name, ManagerBase managerBase) : base(name, managerBase)
        {
        }


        public override void Handle(SickNoteContext sickNoteContext)
        {
            if (sickNoteContext.Hour < 12)
            {
                Console.WriteLine("请假时长小于12小时，项目经理已经批准了");
            }
            else
            {
                Console.WriteLine("项目经理管不了");
                base._managerBase.Handle(sickNoteContext);
            }
        }
    }

    public class ProjectMajor : ManagerBase
    {
        public ProjectMajor(string name, ManagerBase managerBase) : base(name, managerBase)
        {
        }


        public override void Handle(SickNoteContext sickNoteContext)
        {
            if (sickNoteContext.Hour > 12 && sickNoteContext.Hour < 24)
            {
                Console.WriteLine("请假时长大于12小时小于24小时，项目主管已经批准了");
            }
            else
            {
                Console.WriteLine("主管管不了");
                base._managerBase.Handle(sickNoteContext);
            }
        }
    }

    public class CEO : ManagerBase
    {
        public CEO(string name, ManagerBase managerBase) : base(name, managerBase)
        {
        }

        public override void Handle(SickNoteContext sickNoteContext)
        {
            if (sickNoteContext.Hour > 24)
            {
                Console.WriteLine("请假时长大于24小时，CEO已经批准了");
            }
        }
    }
}
