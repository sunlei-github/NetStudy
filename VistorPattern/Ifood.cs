using System;
using System.Collections.Generic;
using System.Text;

namespace VistorPattern
{
    /// <summary>
    /// 食品接口
    /// </summary>
    public interface Ifood
    {
        /// <summary>
        /// 接受一个访问者 允许其访问者可以访问该对象中的所有元素
        /// </summary>
        /// <param name="customerVistor"></param>
        void Accept(CustomerVistorBase customerVistor);

        /// <summary>
        /// 显示物品详细信息 
        /// </summary>
        void Show();
    }

    /// <summary>
    /// 鸡肉食品
    /// </summary>
    public class ChickenFood : Ifood
    {
        public void Accept(CustomerVistorBase customerVistor)
        {
            customerVistor.Visit(this);
        }

        public void Show()
        {
            Console.WriteLine("鸡肉每份12元");
        }
    }

    /// <summary>
    /// 米饭食品
    /// </summary>
    public class RiceFood : Ifood
    {
        public void Accept(CustomerVistorBase customerVistor)
        {
            customerVistor.Visit(this);
        }

        public void Show()
        {
            Console.WriteLine("米饭每份2元");
        }
    }

}
