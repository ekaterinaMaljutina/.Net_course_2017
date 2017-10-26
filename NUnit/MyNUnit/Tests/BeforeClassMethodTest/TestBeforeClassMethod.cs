using System;
using Attributes.Annotation;
using Attributes.MyAssert;

namespace BeforeClassMethodTest
{
    using Assert = MyAssert;

    public class TestBeforeClassMethod
    {
        private object _value;

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
        public void TestMethod()
        {
            Assert.NotEqual(null, _value as Test);
        }
    }
}

