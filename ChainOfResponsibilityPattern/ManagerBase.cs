using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityPattern
{
    /// <summary>
    /// 领导的基类
    /// </summary>
    public abstract class ManagerBase
    {
        protected readonly string _name;

        protected readonly ManagerBase _managerBase;

        public ManagerBase(string name, ManagerBase managerBase)
        {
            _name = name;
           _managerBase = managerBase;
        }

        public abstract void Handle(SickNoteContext sickNoteContext);
    }
}
