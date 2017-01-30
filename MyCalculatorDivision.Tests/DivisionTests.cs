

namespace MyCalculatorDivision.Tests
{
    using MyTests;
    using MyCalculator;
    using System;

    [MyTestsCollection]
    public class DivisionTests
    {
        [MyTest]
        public void DivisionShouldWorkCorrectly()
        {
            var a = 10;
            var b = 5;
            var result = Calculator.Divide(a, b);
            if(result != 2)
            {
                throw new System.Exception($"Expected 2 but received {result}");
            }
        }
        [MyTest]
        [MyExpectedException(typeof(DivideByZeroException))]
        public void DivisionShouldThrowException()
        {
            var a = 10;
            var b = 0;
            Calculator.Divide(a, b);

        }
    }
}
