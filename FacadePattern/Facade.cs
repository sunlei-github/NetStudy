using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class Facade
    {
        private readonly IOldServiceA oldServiceA;
        private readonly IOldServiceB oldServiceB;

        public Facade(IOldServiceA oldServiceA,IOldServiceB oldServiceB)
        {
            this.oldServiceA = oldServiceA;
            this.oldServiceB = oldServiceB;
        }

        public void ShowA()
        {
            oldServiceA.Show();
        }

        public void ShowB()
        {
            oldServiceB.Show();
        }
    }
}
