﻿using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services.Services.Operations
{
    public class Subtraction : IOperation
    {
        public double Execute(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
