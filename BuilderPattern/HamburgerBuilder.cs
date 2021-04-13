using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    /// <summary>
    /// 建造者的基类 负责以后的扩展
    /// </summary>
    public abstract class HamburgerBuilderBase
    {
        protected HamburgerBase hamburger;

        public abstract void BuildHamburger();

        public abstract HamburgerBase GetHamburger();
    }

    /// <summary>
    /// 汉堡包的建造者 
    /// </summary>
    public class HamburgerBuilder : HamburgerBuilderBase
    {
        /// <summary>
        /// 负责建造汉堡包 所需要的其他对象 以及编排他们的顺序  （相当于一个建造者的指挥者）
        /// </summary>
        public override void BuildHamburger()
        {
            IBread bread = new Bread();
            IMeat meat = new Meat();
            ILettuce lettuce = new Lettuce();

            hamburger = new Hamburger(bread, lettuce, meat);
        }

        /// <summary>
        /// 获取所需要的对象
        /// </summary>
        /// <returns></returns>
        public override HamburgerBase GetHamburger()
        {
            if (hamburger == null)
            {
                BuildHamburger();
            }

            return hamburger;
        }
    }
}
