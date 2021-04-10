using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class IdentityCard : ICloneable
    {
        public string Adress { set; get; }

        public IdentityCard(string adress)
        {
            this.Adress = adress;
        }

        public void Show()
        {
            Console.WriteLine($"生成证显示这个人的出生地是{Adress}");
        }

        public object Clone()
        {
            return (object)this.MemberwiseClone();
        }
    }
}
