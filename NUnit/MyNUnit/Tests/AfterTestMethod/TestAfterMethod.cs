using System;
using Attributes.Annotation;
using Attributes.MyAssert;

namespace AfterTestMethod
{
    using Assert = MyAssert;

    public class TestAfterMethod
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
            _value = 100;
        }

        [After]
        public void AfterTest() 
        {
            Assert.Equal(100, _value);
        }
    }
}

