﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern
{
    /// <summary>
    /// 美国人工厂
    /// </summary>
    public class EnglishPeopleFactor : IFactor
    {
        public People CreatePeople()
        {
            return new EnglishPeople();
        }
    }
}
