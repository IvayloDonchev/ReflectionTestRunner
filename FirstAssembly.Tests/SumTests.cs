

namespace FirstAssembly.Tests
{
    using System;
    using MyTests;
    using MyCalculator;
    [MyTestsCollection]
    public class SumTests
    {
        [MyTest]
        public void SumShouldWorkCorrectly()
        {
            var a = 1;
            var b = 2;

            var result = Calculator.Sum(a, b);
            if(result != 3)
            {
                throw new Exception($"Expected 3 but received {result}");
            }
        }
    }
}
