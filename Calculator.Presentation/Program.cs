using Calculator.Entities;
using Calculator.Interfaces;
using Calculator.Service.Interfaces;
using Calculator.Services;
using Calculator.Services.Services.Operations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Dependency Injection
            var serviceProvider = ConfigureServices();

            // Capturar a operação do usuário
            var selectedOperation = SelectOperation(serviceProvider);

            // Capturar os números de entrada do usuário
            Console.WriteLine("Digite o primeiro número: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite o segundo número: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            // Criação do service de calculadora
            var calculatorService = new CalculatorService(selectedOperation);

            // realizar o calculo
            var result = calculatorService.PerformCalculation(num1, num2);

            // Resultado da operação
            Console.WriteLine($"Resultado da operação: ");
            Console.WriteLine(result);
        }

        private static ServiceProvider ConfigureServices()
        {
            // Setup our DI container
            var services = new ServiceCollection();

            // Register operations
            services.AddTransient<Addition>();
            services.AddTransient<Subtraction>();
            services.AddTransient<Multiplication>();
            services.AddTransient<Division>();

            // Register Calculator and CalculatorService
            services.AddTransient<ICalculator, CalculatorEntity>();
            services.AddTransient<CalculatorService>();

            // Build the service provider to resolve dependencies
            return services.BuildServiceProvider();
        }

        // Método para permitir que o usuário selecione a operação
        private static IOperation SelectOperation(ServiceProvider serviceProvider)
        {
            Console.WriteLine("Selecione a operação que deseja realizar:");
            Console.WriteLine("1. Adição");
            Console.WriteLine("2. Subtração");
            Console.WriteLine("3. Multiplicação");
            Console.WriteLine("4. Divisão");
            Console.Write("Escolha (1/2/3/4): ");
            string choice = Console.ReadLine();

            // Seleciona a operação com base na entrada do usuário
            switch (choice)
            {
                case "1":
                    return serviceProvider.GetService<Addition>();
                case "2":
                    return serviceProvider.GetService<Subtraction>();
                case "3":
                    return serviceProvider.GetService<Multiplication>();
                case "4":
                    return serviceProvider.GetService<Division>();
                default:
                    Console.WriteLine("Escolha inválida. Padrão: Adição.");
                    return serviceProvider.GetService<Addition>();
            }
        }
    }
}

