using System;
using System.Collections.Generic;
using System.Text;

namespace VistorPattern
{
    /// <summary>
    /// 定义当中所提到的对象结构，对象结构是一个抽象表述，它内部管理了元素集合，并且可以迭代这些元素提供访问者访问。
    /// </summary>
    public class FoodMenu
    {

        private List<Ifood> foods = new List<Ifood>();

        public void AddFood(Ifood food)
        {
            foods.Add(food);
        }

        public void Show(CustomerVistorBase customerVistor)
        {
            foreach (var food in foods)
            {
                food.Accept(customerVistor);
            }
        }
    }
}
