using System;
using MyUnit.Annotation;
using MyUnit.MyAssert;

namespace BeforeTestMethod
{
    using Assert = MyAssert;

    public class TestBeforeMethod
    {
        private int _value = 0;

        [Before]
        public void BeforeTest()
        {
            Assert.Equal(0, _value);
            _value = 10;
        }

        [Test]
        public void Test()
        {
            Assert.Equal(10, _value);
        }
        
    }
}

