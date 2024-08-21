using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHomework6
{
    internal class Calculator : ICalculator
    {
        public event EventHandler<OperandChangedEventArgs> GotResult;
        private Stack<double> stack = new Stack<double>();
        private double Result
        {
            get
            {
                return stack.Count() == 0 ? 0 : stack.Peek();
            }
            set
            {
                stack.Push(value);
                RaiseEvent();
            }
        }
        public void RaiseEvent()
        {
            GotResult.Invoke(this, new OperandChangedEventArgs(Result));
        }
        public void CancelLast()
        {
            if (stack.Count > 0)
            {
                stack.Pop();
                RaiseEvent();
            }
        }
        public void Divide(double number)
        {
            try
            {
                checked
                {
                    if (number != 0)
                    {
                        Result /= number;
                    }
                    else
                    {
                        throw new CalculatorDivideByZeroException("Деление на ноль!");
                    }
                }
            }
            catch (OverflowException)
            {
                throw new CalculateOperationCauseOverflowException("Слишком большое число.");
            }
        }

        public void Multiply(double number)
        {
            try
            {
                checked
                {
                    Result *= number;
                }
            }
            catch (DivideByZeroException)
            {
                throw new CalculateOperationCauseOverflowException("Слишком большое число.");
            }

        }

        public void Substract(double number)
        {
            try
            {
                checked
                {
                    Result -= number;
                }
            }
            catch (DivideByZeroException)
            {
                throw new CalculateOperationCauseOverflowException("Слишком большое число.");
            }
        }

        public void Sum(double number)
        {
            try
            {
                checked
                {
                    Result += number;
                }
            }
            catch (DivideByZeroException)
            {
                throw new CalculateOperationCauseOverflowException("Слишком большое число.");
            }
        }

        public void Divide(int number)
        {
            try
            {
                checked
                {
                    if (number != 0)
                    {
                        Result /= number;
                    }
                    else
                    {
                        throw new CalculatorDivideByZeroException("Деление на ноль!");
                    }
                }
            }
            catch (OverflowException)
            {
                throw new CalculateOperationCauseOverflowException("Слишком большое число.");
            }
        }

        public void Multiply(int number)
        {
            try
            {
                checked
                {
                    Result *= number;
                }
            }
            catch (DivideByZeroException)
            {
                throw new CalculateOperationCauseOverflowException("Слишком большое число.");
            }

        }

        public void Substract(int number)
        {
            try
            {
                checked
                {
                    Result -= number;
                }
            }
            catch (DivideByZeroException)
            {
                throw new CalculateOperationCauseOverflowException("Слишком большое число.");
            }
        }

        public void Sum(int number)
        {
            try
            {
                checked
                {
                    Result += number;
                }
            }
            catch (DivideByZeroException)
            {
                throw new CalculateOperationCauseOverflowException("Слишком большое число.");
            }
        }
    }
}
