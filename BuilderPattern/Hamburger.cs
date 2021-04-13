using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class Hamburger : HamburgerBase
    {
        private readonly IBread bread;
        private readonly ILettuce lettuce;
        private readonly IMeat meat;

        public Hamburger(IBread bread, ILettuce lettuce, IMeat meat)
        {
            this.bread = bread;
            this.lettuce = lettuce;
            this.meat = meat;
        }

        /// <summary>
        /// 显示汉堡包
        /// </summary>
        public override  void Show()
        {
            bread.Build();
            lettuce.Build();
            meat.Build();
            lettuce.Build();
            meat.Build();

            Console.WriteLine("汉堡包弄好了");
        }
    }

    public interface IBread
    {
        void Build();
    }

    public class Bread : IBread
    {
        public void Build()
        {
            Console.WriteLine("建造一块面包");
        }
    }

    public interface ILettuce
    {
        void Build();
    }

    public class Lettuce : ILettuce
    {
        public void Build()
        {
            Console.WriteLine("建造一块生菜");
        }
    }

    public interface IMeat
    {
        void Build();
    }

    public class Meat : IMeat
    {
        public void Build()
        {
            Console.WriteLine("建造一块生菜");
        }
    }
}
