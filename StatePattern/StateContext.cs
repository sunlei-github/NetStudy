using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    public class StateContext
    {
        private StateStepBase _stateStep = null;
        public string State { set; get; }

        public StateContext(StateStepBase state)
        {
            // 初始化第一个状态的分支步骤
            _stateStep = state;
        }

        public void Handler()
        {
            _stateStep.Invoke(this);
        }
    }
}
