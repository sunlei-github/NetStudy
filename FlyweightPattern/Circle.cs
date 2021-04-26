using System;
using System.Collections.Generic;
using System.Text;

namespace FlyweightPattern
{
    /// <summary>
    /// 圆
    /// </summary>
    public class Circle
    {
        private readonly string color;

        public Circle(string  color)
        {
            this.color = color;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"在x轴{x}y轴{y}的地方画了一个{color}的圆");
        }
    }
}
