using Calculator.Entities;
using Calculator.Interfaces;
using Calculator.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculator _calculator;

        public CalculatorService(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public CalculatorService(IOperation operation)
        {
            _calculator = new CalculatorEntity(operation);
        }

        public double PerformCalculation(double num1, double num2)
        {
            return _calculator.Calculate(num1, num2);
        }
    }


}
