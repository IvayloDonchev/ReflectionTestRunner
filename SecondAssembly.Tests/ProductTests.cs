namespace MyCalculatorProduct.Tests
{
    using MyCalculator;
    using MyTests;
    using System;

    [MyTestsCollection]
    public class ProductTests
    {
        [MyTest]
        public void ProductShouldWorkCorrectly()
        {
            var a = 4;
            var b = 20;
            var result = Calculator.Product(a, b);
            if(result != 80)
            {
                throw new Exception($"Expected 80 but received {result}");

            }
        }
    }
}
