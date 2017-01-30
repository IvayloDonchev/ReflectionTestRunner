namespace MyTests
{
    using System;
    public class MyExpectedExceptionAttribute : Attribute
    {
        public MyExpectedExceptionAttribute()
        { }
        public MyExpectedExceptionAttribute(Type expectedException)
        {
            this.ExpectedException = expectedException;
        }
        public Type ExpectedException { get; private set; }
    }
}
