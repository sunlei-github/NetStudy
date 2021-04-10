using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    /// <summary>
    /// ICloneable 该接口就是为了创建一个新的对象
    /// </summary>
    public class People : ICloneable
    {
        public string Name { get; set; }

        public int Old { get; set; }

        public IdentityCard IdentityCard { set; get; }

        public People(string name, int old)
        {
            Name = name;
            Old = old;
        }

        public void Show()
        {
            Console.WriteLine($"我的名字叫做{Name}今年{Old}岁");
            if (IdentityCard != null)
            {
                IdentityCard.Show();
            }
        }

        public object Clone()
        {
            var copyPeople = (People)this.MemberwiseClone();
            if (this.IdentityCard != null)
            {
                copyPeople.IdentityCard = (IdentityCard)this.IdentityCard.Clone();  //对于引用类型再进行一次浅克隆 
            }

            return copyPeople as object;  
        }
    }
}
