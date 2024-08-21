using Microsoft.VisualBasic;
using System.Linq.Expressions;

namespace CSharpHomework6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? action = "";

            ICalculator calculator = new Calculator();
            calculator.GotResult += Calculator_GotResult;
            Logger logger = new Logger();

            while (true)
            {
                try
                {
                    Console.Write("Введите число: ");
                    string? input = Console.ReadLine();
                    if (input.Equals("q") || input.Equals("")) return;

                    Console.Write("Введите арифметическое действие: ");
                    action = Console.ReadLine();

                    logger.AddLog(input, action);

                    if (input.Contains(','))
                    {
                        double number = ReadDouble(input);
                        switch (action)
                        {
                            case "+":
                                Console.WriteLine(number.GetType());
                                calculator.Sum(number);
                                break;
                            case "-":
                                calculator.Substract(number);
                                break;
                            case "*":
                                calculator.Multiply(number);
                                break;
                            case "/":
                                calculator.Divide(number);
                                break;
                            case "q":
                                return;
                            case "":
                                return;
                            default:
                                Console.WriteLine("Вы ввели неверное действие!");
                                Console.WriteLine();
                                break;
                        }
                    }
                    else
                    {
                        int number = ReadInt(input);
                        switch (action)
                        {
                            case "+":
                                Console.WriteLine(number.GetType());
                                calculator.Sum(number);
                                break;
                            case "-":
                                calculator.Substract(number);
                                break;
                            case "*":
                                calculator.Multiply(number);
                                break;
                            case "/":
                                calculator.Divide(number);
                                break;
                            case "q":
                                return;
                            case "":
                                return;
                            default:
                                Console.WriteLine("Вы ввели неверное действие!");
                                Console.WriteLine();
                                break;
                        }
                    }
                }
                catch (CalculateOperationCauseOverflowException ex)
                {
                    Console.WriteLine(logger.GetLog() + ex.Message);
                }
                catch (CalculatorDivideByZeroException ex)
                {
                    Console.WriteLine(logger.GetLog() + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(logger.GetLog() + ex.Message);
                }
            }

            static void Calculator_GotResult(object? sender, OperandChangedEventArgs e)
            {
                Console.WriteLine($"Итог: {e.Operand}");
                Console.WriteLine();
            }

            static double ReadDouble(string? input)
            {
                double i;
                while (!double.TryParse(input, out i))
                {
                    Console.WriteLine("Вы ввели не число!");
                    input = Console.ReadLine();
                }
                return i;
            }
            static int ReadInt(string? input)
            {
                int i;
                while (!int.TryParse(input, out i))
                {
                    Console.WriteLine("Вы ввели не число!");
                    input = Console.ReadLine();
                }
                return i;
            }
        }
    }
}
