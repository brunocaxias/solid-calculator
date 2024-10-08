using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class CalculatorService
    {
        private readonly ICalculator _calculator;

        public CalculatorService(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public void PerformCalculation(double num1, double num2)
        {
            var result = _calculator.Calculate(num1, num2);
            Console.WriteLine($"Calculation Result: {result}");
        }
    }


}
