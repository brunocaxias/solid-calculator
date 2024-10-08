using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Entities
{
    public class CalculatorEntity : ICalculator
    {
        private readonly IOperation _operation;

        public CalculatorEntity(IOperation operation)
        {
            _operation = operation;
        }

        public double Calculate(double num1, double num2)
        {
            if (_operation == null)
            {
                throw new InvalidOperationException("Nenhuma operação foi definida.");
            }

            return _operation.Execute(num1, num2);
        }
    }

}
