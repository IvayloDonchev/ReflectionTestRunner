
using System.Threading.Tasks;

namespace MyCalculator
{
    using System;
    public static class Calculator
    {
        public static int Sum(int first, int second) => first + second;
        public static int Product(int first, int second) => first * second;
        public static decimal Divide(int first, decimal second)
        {
            if(second == 0)
            {
                throw new DivideByZeroException();
            }
            return first / second;
        }
    }
}
