using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class OldServiceB : IOldServiceB
    {
        public void Show()
        {
            Console.WriteLine("旧系统的服务B");
        }
    }

    public interface IOldServiceB
    {
        void Show();
    }
}
