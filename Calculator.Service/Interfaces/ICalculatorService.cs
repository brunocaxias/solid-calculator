using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Service.Interfaces
{
    public interface ICalculatorService
    {
        public double PerformCalculation(double num1, double num2);
    }
}
