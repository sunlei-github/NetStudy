using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class NewService : INewService
    {
        private readonly Facade facade;

        public NewService(Facade facade)
        {
            this.facade = facade;
        }

        public void ShowA()
        {
            Console.WriteLine("我是新系统服务A，要调用旧系统的服务A");
            facade.ShowA();
        }

        public void ShowB()
        {
            Console.WriteLine("我是新系统服务B，要调用旧系统的服务B");
            facade.ShowB();
        }
    }

    public interface INewService
    {
        void ShowA();

        void ShowB();
    }
}
