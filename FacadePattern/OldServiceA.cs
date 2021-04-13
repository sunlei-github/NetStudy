using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class OldServiceA : IOldServiceA
    {
        public void Show()
        {
            Console.WriteLine("旧系统的服务A");
        }
    }

    public interface IOldServiceA
    {
        void Show();
    }
}
