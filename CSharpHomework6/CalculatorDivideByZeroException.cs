﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHomework6
{
    internal class CalculatorDivideByZeroException:DivideByZeroException
    {
        public CalculatorDivideByZeroException(string message) : base(message) { }        
    }
}
