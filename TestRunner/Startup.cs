namespace TestRunner
{
    using System.IO;
    using System.Linq;
    using MyTests;
    using System.Reflection;
    using System;

    public class Startup
    {
        static void Main()
        {
            var testClasses = AssemblyLoader
                .Load()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsDefined(typeof(MyTestsCollectionAttribute), true));

            int totalTests = 0;
            int passedTests = 0;
            foreach (var testClass in testClasses)
            {
                object testClassInstance;
                try
                {

                    testClassInstance = Activator.CreateInstance(testClass);
                }
                catch
                {
                    Console.WriteLine($"WARNING: {testClass.FullName} do not have empty constructor...");
                    continue;
                }
               
                var tests = testClass
                    .GetMethods()
                    .Where(m => m.IsDefined(typeof(MyTestAttribute), true));

               foreach(var test in tests)
                {
                    if (test.GetParameters().Length > 0)
                    {
                        Console.WriteLine($"WARNING: {test.Name} must not have any parameters...");
                        continue;
                    }
                    totalTests++;
                    try
                    {
                        test.Invoke(testClassInstance, new object[0]);    
                    }
                   
                    catch(TargetInvocationException ex)
                    {
                        var expectedExceptionAttribute = test.GetCustomAttribute<MyExpectedExceptionAttribute>();
                        if(expectedExceptionAttribute == null)
                        {
                            Console.WriteLine($"{test.Name} failed {ex.InnerException.Message}");
                            continue;
                        }
                        else if (expectedExceptionAttribute != null 
                            && expectedExceptionAttribute.ExpectedException != ex.InnerException.GetType())
                        {
                            Console.WriteLine($"{test.Name} failed. Epected {expectedExceptionAttribute.ExpectedException.Name} exception but received {ex.InnerException.GetType().Name}");
                            continue;
                        }             
                    }
                    passedTests++;
                }
            }
            Console.WriteLine($"Total tests: {totalTests}");
            Console.WriteLine($"Passed tests: {passedTests}");
            Console.WriteLine($"Failed tests: { totalTests - passedTests}");
        }
    }
}
