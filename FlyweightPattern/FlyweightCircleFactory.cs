using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FlyweightPattern
{
    /// <summary>
    /// 共享模式的工厂
    /// </summary>
    public class FlyweightCircleFactory
    {

        private Dictionary<string, Circle> keyValuePairs = new Dictionary<string, Circle>();

        /// <summary>
        /// 共享对象
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Circle GetCircle(string color)
        {
            if (!keyValuePairs.Keys.Contains(color))
            {
                keyValuePairs.Add(color, new Circle(color));
            }

            return keyValuePairs[color];
        }

        public void ShowCircleCount()
        {
            Console.WriteLine($"一共创建的对象的数量{ keyValuePairs.Count}");
        }
    }
}
