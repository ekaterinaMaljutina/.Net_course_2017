using System;
using MyUnit.Annotation;
using MyUnit.MyAssert;

namespace BeforeClassMethodTest
{
    using Assert = MyAssert;

    public class TestBeforeClassMethod
    {
        private Object _value = null;

        [BeforeClass]
        public void BeforeClassMethod()
        {
            _value = new Test();
        }

        [Before]
        public void BeforeMethod()
        {
            if (_value == null)
            {
                _value = new Random();
            }
        }

        [Test]
        public void testMethod()
        {
            Assert.NotEqual(null, _value as Test);
        }
    }
}

