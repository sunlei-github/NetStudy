using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactorPattern
{
    public interface IFactor
    {
        People CreatePeople();
    }
}
