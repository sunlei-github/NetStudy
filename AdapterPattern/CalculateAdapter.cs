using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern
{
    public class CalculateAdapter: IOurSyetemOperation
    {
        private readonly ThridPartyCalculate thridPartyCalculate;

        public CalculateAdapter(ThridPartyCalculate thridPartyCalculate)
        {
            this.thridPartyCalculate = thridPartyCalculate;
        }

        public double Add(double num1, double num2)
        {
            return thridPartyCalculate.Calculate(num1, num2, "+");
        }

        public double Sub(double num1, double num2)
        {
            return thridPartyCalculate.Calculate(num1, num2, "-");
        }

        public double Mul(double num1, double num2)
        {
            return thridPartyCalculate.Calculate(num1, num2, "*");
        }

        public double Div(double num1, double num2)
        {
            return thridPartyCalculate.Calculate(num1, num2, "/");
        }

    }
}
