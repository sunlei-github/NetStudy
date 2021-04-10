using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern
{
    public interface IFactor
    {
        People CreatePeople();
    }
}
