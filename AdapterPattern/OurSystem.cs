using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern
{
    /// <summary>
    /// 我们自己的系统 需要调用第三方的接口去实现计算
    /// 但是我们现在已经有了计算对应的接口  为了适配这些接口我们使用适配器模式
    /// </summary>
    public interface IOurSyetemOperation
    {
        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        double Add(double num1, double num2);

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        double Sub(double num1, double num2);

        /// <summary>
        /// 乘法
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        double Mul(double num1, double num2);

        /// <summary>
        /// 除法
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        double Div(double num1, double num2);
    }

    /// <summary>
    /// 我们的系统需要使用第三方的计算时 由于参数对不上 所以需要创建一个适配器去适配我们的系统
    /// </summary>
    public class OurSyetemOperation : IOurSyetemOperation
    {
        private readonly CalculateAdapter calculateAdapter;

        public OurSyetemOperation(CalculateAdapter calculateAdapter)
        {
            this.calculateAdapter = calculateAdapter;
        }

        public double Add(double num1, double num2)
        {
            return calculateAdapter.Add(num1, num2);
        }

        public double Div(double num1, double num2)
        {
            return calculateAdapter.Div(num1, num2);
        }

        public double Mul(double num1, double num2)
        {
            return calculateAdapter.Mul(num1, num2);
        }

        public double Sub(double num1, double num2)
        {
            return calculateAdapter.Sub(num1, num2);
        }
    }
}
